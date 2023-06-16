using UnityEngine;

public class UiManager : MonoBehaviour {
    [SerializeField] private Canvas _startUi;
    [SerializeField] private Canvas _talkUi;
    [SerializeField] private Canvas _tradeUi;
    [SerializeField] private Canvas _inGameUi;
    [SerializeField] private Canvas _turnUi;
    [SerializeField] private Canvas _turnEndUi;
    [SerializeField] private TMPro.TMP_Text inGameText;
    [SerializeField] private TMPro.TMP_Text turnText;


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
}