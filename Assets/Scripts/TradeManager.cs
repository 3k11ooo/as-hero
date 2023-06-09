using UnityEngine;
using TMPro;

public class TradeManager : MonoBehaviour {
    [SerializeField] private TradingViewController tradingViewControllerScript;
    private string loadText;
    private string[] splitText;

    private int textNum;

    public void LoadTextData(string loadFileName) {
        loadText = (Resources.Load(loadFileName, typeof(TextAsset)) as TextAsset).text;
        splitText = loadText.Split(char.Parse("\n"));
        textNum = 0;
        tradingViewControllerScript.ChangeViewText(splitText[textNum]);
    }

    public void ChangeViewTextData() {
        Debug.Log(textNum);
        tradingViewControllerScript.ChangeViewText(splitText[textNum]);
        textNum++;
    }


}