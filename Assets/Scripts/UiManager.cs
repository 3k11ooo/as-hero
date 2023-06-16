using UnityEngine;
using System.Text.RegularExpressions;

public class UiManager : MonoBehaviour {
    [SerializeField] private Canvas _startUi;
    [SerializeField] private Canvas _talkUi;
    [SerializeField] private Canvas _tradeUi;
    [SerializeField] private Canvas _inGameUi;
    [SerializeField] private Canvas _turnUi;
    [SerializeField] private Canvas _turnEndUi;
    [SerializeField] private TMPro.TMP_Text inGameText;
    [SerializeField] private TMPro.TMP_Text turnText;
    [SerializeField] private TMPro.TMP_Text playerHold;


        // UI管理
    public void ManageUI(GameState state) {
        switch(state) {
            case GameState.GAMESTART :
                _startUi.enabled = true;
                _talkUi.enabled = false;
                _tradeUi.enabled = false;
                _inGameUi.enabled = false;
                _turnUi.enabled = false;
                _turnEndUi.enabled = false;
                break;
            case GameState.INGAME_WALK :
                _startUi.enabled = false;
                _talkUi.enabled = false;
                _tradeUi.enabled = false;
                _turnUi.enabled = true;
                break;
            case GameState.INGAME_TRADE :
                _startUi.enabled = false;
                _talkUi.enabled = false;
                _tradeUi.enabled = true;
                break;
            case GameState.INGAME_TALK :
                _startUi.enabled = false;
                _talkUi.enabled = true;
                _tradeUi.enabled = false;
                break;
            case GameState.GAMEENDING :
                _startUi.enabled = false;
                _talkUi.enabled = false;
                _tradeUi.enabled = false;
                break;
            case GameState.PAUSE :
                _startUi.enabled = false;
                _talkUi.enabled = false;
                _tradeUi.enabled = false;
                break;
            case GameState.GAMEOVER :
                _startUi.enabled = false;
                _talkUi.enabled = false;
                _tradeUi.enabled = false;            
                break; 
            default:
                _startUi.enabled = false;
                _talkUi.enabled = false;
                _tradeUi.enabled = false;
                break;
        }
    }

    // _inGameUiの管理
    public void InGameUIControl(bool overlap, string text) {
        _inGameUi.enabled = overlap;
        inGameText.SetText("スペースキーで"+text);
    }
     // turn 管理
    public void TurnViewController(int count,  string[] turnData) {
        turnText.SetText(turnData[count]);
    }
    // asset manage
    public void AssetViewControl(string[] assetData, string[] assetName) {
        string fullWidthStr = "";
        for (int i=0; i<assetData.Length; i++) {
            fullWidthStr += (assetName[i] + "ーー");
            fullWidthStr += ConvertToFullWidth(assetData[i]);
            fullWidthStr += "\n";
        }
        playerHold.SetText(fullWidthStr);
    }

    public void TurnEndViewControl(bool turnEnd) {
        if (turnEnd == true) {
            _inGameUi.enabled = false;
            _turnUi.enabled = false;
            _turnEndUi.enabled = true;
        }
        else {
            _inGameUi.enabled = true;
            _turnUi.enabled = true;
            _turnEndUi.enabled = false;
        }
    }

    const int ConvertionConstant = 65248;

    static public string ConvertToFullWidth(string halfWidthStr)
    {
        string fullWidthStr = null;

        for (int i = 0; i < halfWidthStr.Length; i++)
        {
            fullWidthStr += (char)(halfWidthStr[i] + ConvertionConstant);
        }

        return fullWidthStr;
    }
}