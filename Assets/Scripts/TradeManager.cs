using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Collections.Generic;

public class TradeManager : MonoBehaviour {
    // FIXME: enumはあとで外だし
    enum TradeState {
        SELECT,
        BUY,
        SELL,
        ERROR,
        END,
    }
    enum AssetState {
        NONE,
        STABLE,
        ACTIVE,
        FX,
        SAVE,
    }
    
    [SerializeField] private TradingViewController tradingViewControllerScript;
    public UnityEvent endTrade = new UnityEvent();
    private string loadText;
    private string[] splitText;
    private TradeState tradeState; 
    private AssetState assetState;
    private StableAssetData stableAsset = new StableAssetData("stable");
    private ActiveAssetData activeAsset = new ActiveAssetData("active");
    private FxAssetData fxAsset = new FxAssetData("fx");
    private SavingAssetData savingAsset = new SavingAssetData("saving");
    private PlayerAssetData playerAssetData = new PlayerAssetData();
    private string nowStableRate = "";
    private string nowActiveRate = "";
    private string nowFxRate = "";
    private string nowSaveRate = "";
    private string beforeLoadFileName = "";
    private TradeState beforeTradeState;
    private string nowPlayerHold = "0";
    private string nowStableReturn = "0";
    private string nowActiveReturn = "0";
    private string nowFxReturn = "0";
    private string nowSaveReturn = "0";



    private int textNum;

    public void LoadTextData(string loadFileName) {
        loadText = (Resources.Load(loadFileName, typeof(TextAsset)) as TextAsset).text;
        switch (loadFileName) {
            case "stableAssetText":
                loadText = loadText.Replace("rate", ConvertToFullWidth(nowStableRate));
                break;
            case "activeAssetText":
                loadText = loadText.Replace("rate", ConvertToFullWidth(nowActiveRate));
                break;
            case "fxAssetText":
                loadText = loadText.Replace("rate", ConvertToFullWidth(nowFxRate));
                break;
            case "savingAssetText":
                loadText = loadText.Replace("rate", ConvertToFullWidth(nowSaveRate));
                break;
            default :
                break;
        }
        tradingViewControllerScript.ChangeViewText(loadText);
    }

    public void init() {
        tradeState = TradeState.SELECT;
        assetState = AssetState.NONE;
        playerAssetData.PlayerHold = 1000f;
        LoadTextData("tradeBrand");
    }
    // NOTE:  update
    public void PlayerTradeController(KeyCode code) {
        if (tradeState == TradeState.SELECT && assetState == AssetState.NONE) {
            SelectAsset(code);            
        }
        else if (tradeState == TradeState.SELECT && assetState != AssetState.NONE) {
            SelectBuyOrSell(code);
        }
        else if (tradeState == TradeState.BUY || tradeState == TradeState.SELL) {
            SelectPrice(code);
        }
        else if (tradeState == TradeState.END && code == KeyCode.Escape) {
            ChangeViewData();
            endTrade.Invoke();
            init();
        }
        else if (tradeState == TradeState.ERROR && code == KeyCode.Space) {
            ErrorControl();
        }
    }

    public void ChangeReturnRate() {
        nowStableRate = stableAsset.CalReturnRate();
        nowActiveRate = activeAsset.CalReturnRate();
        nowFxRate = fxAsset.CalReturnRate();
        nowSaveRate = savingAsset.CalReturnRate();
    }
    public void ChangePlayerHold() {
        playerAssetData.PlayerHold += 1000f;
        playerAssetData.StableAsset += stableAsset.CalReturn(playerAssetData.StableAsset);
        playerAssetData.ActiveAsset += activeAsset.CalReturn(playerAssetData.ActiveAsset);
        playerAssetData.FxAsset += fxAsset.CalReturn(playerAssetData.FxAsset);
        playerAssetData.SavingAsset += savingAsset.CalReturn(playerAssetData.SavingAsset);
    }

    private void SelectAsset(KeyCode code) { // none
        switch(code) {
            case KeyCode.Alpha1:
                LoadTextData("stableAssetText");
                assetState = AssetState.STABLE;
                beforeLoadFileName = "stableAssetText";
                break;
            case KeyCode.Alpha2:
                LoadTextData("activeAssetText");
                assetState = AssetState.ACTIVE;
                beforeLoadFileName = "activeAssetText";
                break;
            case KeyCode.Alpha3:
                LoadTextData("fxAssetText");
                assetState = AssetState.FX;
                beforeLoadFileName = "fxAssetText";
                break;
            case KeyCode.Alpha4:
                LoadTextData("savingAssetText");
                assetState = AssetState.SAVE;
                beforeLoadFileName = "savingAssetText";
                break;
            case KeyCode.Escape:
                endTrade.Invoke();
                break;
            default:
                break;
        }
    }
    private void SelectBuyOrSell(KeyCode code) { // buy or sell or back
        switch(code) {
            case KeyCode.Alpha1: // buy
                tradeState = TradeState.BUY;
                LoadTextData("selectAssetPrice");
                break;
            case KeyCode.Alpha2: // sell
                tradeState = TradeState.SELL;
                LoadTextData("selectAssetPrice");
                break;
            case KeyCode.Alpha3: // back to select brand
                LoadTextData("tradeBrand");
                assetState = AssetState.NONE;
                break;
            default:
                break;
        }
    }
    private void SelectPrice(KeyCode code) { // trade state == buy or sell
        switch (code) {
            case KeyCode.Alpha1: // 100
                ReferTradeState(100f);
                break;
            case KeyCode.Alpha2: // 500 
                ReferTradeState(500f);
                break;
            case KeyCode.Alpha3: // 1000
                ReferTradeState(1000f);
                break;
            case KeyCode.Alpha4: // back 
                LoadTextData(beforeLoadFileName);
                tradeState = TradeState.SELECT;
                break;
            default:
                break;
        }
    }
    private void ReferTradeState(float amount) {
        if (tradeState == TradeState.BUY) {
            switch (assetState) {
                case AssetState.STABLE:
                    playerAssetData.StableAsset = CalAssetTrade(playerAssetData.StableAsset, amount);
                    break;
                case AssetState.ACTIVE:
                    playerAssetData.ActiveAsset = CalAssetTrade(playerAssetData.ActiveAsset, amount);
                    break;
                case AssetState.FX:
                    playerAssetData.FxAsset = CalAssetTrade(playerAssetData.FxAsset, amount);
                    break;
                case AssetState.SAVE:
                    playerAssetData.SavingAsset = CalAssetTrade(playerAssetData.SavingAsset, amount);
                    break;
                default:
                    break;
            }
        }
        else if (tradeState == TradeState.SELL) {
            switch (assetState) {
                case AssetState.STABLE:
                    playerAssetData.StableAsset = CalAssetTrade(playerAssetData.StableAsset, -amount);
                    break;
                case AssetState.ACTIVE:
                    playerAssetData.ActiveAsset = CalAssetTrade(playerAssetData.ActiveAsset, -amount);
                    break;
                case AssetState.FX:
                    playerAssetData.FxAsset = CalAssetTrade(playerAssetData.FxAsset, -amount);
                    break;
                case AssetState.SAVE:
                    playerAssetData.SavingAsset = CalAssetTrade(playerAssetData.SavingAsset, -amount);
                    break;
                default:
                    break;
            }
        }
    }
    private float CalAssetTrade(float assetHold, float tradeAmount) {
        if (tradeAmount < 0 && -tradeAmount > assetHold ) {
            ErrorControl();
            return assetHold;
        }
        else if (tradeAmount < 0 && playerAssetData.PlayerHold < tradeAmount) {
            ErrorControl();
            return assetHold;
        }
        else {
            playerAssetData.PlayerHold -= tradeAmount;
            LoadTextData("endTradeText");
            tradeState = TradeState.END;
            return assetHold + tradeAmount;
        }
    }
    private void ErrorControl() {
        if (tradeState != TradeState.ERROR) {
            tradingViewControllerScript.ViewErrorText(true);
            beforeTradeState = tradeState;
            tradeState = TradeState.ERROR;
        }
        else {
            tradingViewControllerScript.ViewErrorText(false);
            tradeState =  beforeTradeState;
            LoadTextData("selectAssetPrice");
        }

    }
    public void ChangeViewData() {
        nowPlayerHold = playerAssetData.PlayerHold.ToString("#;-#;0");
        nowStableReturn = playerAssetData.StableAsset.ToString("#.##;{#.##;0");
        nowActiveReturn = playerAssetData.ActiveAsset.ToString("#.##;{#.##;0");
        nowFxReturn = playerAssetData.FxAsset.ToString("#.##;{#.##;0");
        nowSaveReturn = playerAssetData.SavingAsset.ToString("#.##;{#.##;0");
    }

    public string[] GetAssetName() {
        string[] strArray = new string[5] {
            "てもち",
            "あんていかぶ",
            "アクテイブかぶ",
            "かわせ",
            "よきん",
        };
        return strArray;
    }
    public string[] GetAssetHold() {
        string[] strArray = new string[5] {
            nowPlayerHold,
            nowStableReturn,
            nowActiveReturn,
            nowFxReturn,
            nowSaveReturn,
        };
        return strArray;
    }


    const int ConvertionConstant = 65248;
    static public string ConvertToFullWidth(string halfWidthStr) {
        string fullWidthStr = null;
        for (int i = 0; i < halfWidthStr.Length; i++) {
            fullWidthStr += (char)(halfWidthStr[i] + ConvertionConstant);
        }
        return fullWidthStr;
    }

    // IEnumerator Trade() {
    //     //終わるまで待ってほしい処理を書く

    
    //     //1秒待つ
    //     yield return new WaitForSeconds(1);
    
    //     //再開してから実行したい処理を書く

    // } 


    // talk??
    // public void ChangeViewTextData() {
    //     Debug.Log(textNum);
    //     tradingViewControllerScript.ChangeViewText(splitText[textNum]);
    //     textNum++;
    // }
}