using UnityEngine;
using TMPro;

public class EndingManager : MonoBehaviour {
    [SerializeField] private TMPro.TMP_Text _resultText ;
    private string resultText;

    public void ChangeResultTextData(float resultSum) {
        float num = resultSum / 1000f;
        string strSum;
        if (resultSum < 0) {
            strSum = "｛";
        }
        strSum = ConvertToFullWidth(resultSum.ToString("#.###;0"));
        string strNum = ConvertToFullWidth(num.ToString("#.###;0"));
        resultText += "あなた　は　１０ねん　で　\n" + strSum + "　えん　ふやしました！\n\n";
        resultText += "そんえきりつ　は　" + strNum + "　ばい　です\n\n\n";
        resultText += "スペースキー　で　スタートがめん　に　もどります。";
        _resultText.SetText(resultText);
    }

    const int ConvertionConstant = 65248;
    static public string ConvertToFullWidth(string halfWidthStr) {
        string fullWidthStr = null;
        for (int i = 0; i < halfWidthStr.Length; i++) {
            fullWidthStr += (char)(halfWidthStr[i] + ConvertionConstant);
        }
        return fullWidthStr;
    }
}