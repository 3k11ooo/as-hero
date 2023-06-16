using UnityEngine;
using TMPro;

public class TradeManager : MonoBehaviour {
    [SerializeField] private TradingViewController tradingViewControllerScript;
    private string loadText;
    private string[] splitText;
    private TradeState tradeState; 

    private int textNum;
    // FIXME: enumはあとで外だし
    enum TradeState {
        BUY,
        SELL
    }
    public void LoadTextData(string loadFileName) {
        loadText = (Resources.Load(loadFileName, typeof(TextAsset)) as TextAsset).text;
        // splitText = loadText.Split(char.Parse("\n"));
        tradingViewControllerScript.ChangeViewText(loadText);
        // for (int i=0; i<splitText.Length; i++){
        //     tradingViewControllerScript.ChangeViewText(splitText[i]);
        // }
    }

    public void init() {
        tradeState = TradeState.BUY;
        LoadTextData("tradeBrand");
    }



    public void BuySellAsset() {
        if (tradeState == TradeState.BUY) {
            // FIXME: 各アセットごとのクラスを作る
            // FIXME: playerdataにAseetのデータを作る
            // それを参照して処理をする。

        }
        else {

        }
    }

    // talk??
    public void ChangeViewTextData() {
        Debug.Log(textNum);
        tradingViewControllerScript.ChangeViewText(splitText[textNum]);
        textNum++;
    }

    public void PlayerTradeController(KeyCode code) {
        switch(code) {
            case KeyCode.Keypad1:
                break;
            case KeyCode.Keypad2:
                break;
            case KeyCode.Keypad3:
                break;
            case KeyCode.Keypad4:
                break;
            default:
                break;
        }
    }



}