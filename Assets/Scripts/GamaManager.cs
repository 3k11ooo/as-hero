using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamaManager : MonoBehaviour {
    //  参照しましょう
    [SerializeField] private KeyInput keyInputScript; 
    [SerializeField] private ViewController viewControllerScript;
    [SerializeField] private SceneManager sceneManagerScript;
    [SerializeField] private PlayerController playerControllerScript;
    [SerializeField] private TradeManager tradeManagerScript;
    [SerializeField] private KeyInputManager keyInputManager;
    [SerializeField] private KeyInputManager keyInputManagerEvent;
    [SerializeField] private Canvas _startUi;
    [SerializeField] private Canvas _talkUi;
    [SerializeField] private Canvas _tradeUi;



    private GameData gameData = new GameData();

    private void Awake() {
        DontDestroyOnLoad(this);
        SceneInitManagement();
        initTradeTextData();
        StateManage(GameState.GAMESTART);
        SubscribeToEvent(keyInputManagerEvent);
        keyInputManager.initKeyInputManager();
    }


    public void GetKeyInput(KeyCode code) {
        // 管理
        switch(gameData.NowGameState) {
            case GameState.GAMESTART :
                keyInputManager.StartGame(code);
                break;
            case GameState.INGAME_WALK :
                keyInputManager.Walk(code);
                break;
            case GameState.INGAME_TRADE :
                break;
            case GameState.INGAME_TALK :
                break;
            case GameState.GAMEENDING :
                break;
            case GameState.PAUSE :
                break;
            case GameState.GAMEOVER :
                break; 
            default:
                break;
        }
    }


    private void SceneInitManagement() {
        switch (gameData.NowSceneState) {
            case SceneState.HOME:
                playerControllerScript.init(new Vector2(3f, -3f));
                break;
        }
        Debug.Log(gameData.NowSceneState);
    }

    private void StateManage(GameState nextState) {
        gameData.NowGameState = nextState;
        ManageUI();
        Debug.Log(gameData.NowGameState);
    }

    // 取引の顔面管理
    private void initTradeTextData() {
        tradeManagerScript.LoadTextData("tradeBrand");
    }

    // UI管理
    private void ManageUI() {
        switch(gameData.NowGameState) {
            case GameState.GAMESTART :
                _startUi.enabled = true;
                _talkUi.enabled = false;
                _tradeUi.enabled = false;
                break;
            case GameState.INGAME_WALK :
                _startUi.enabled = false;
                _talkUi.enabled = false;
                _tradeUi.enabled = false;
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


    // input managerからのイベント取得
    private void SubscribeToEvent(KeyInputManager eventHolder) {
        Debug.Log("Subscribed");
        this.keyInputManagerEvent = eventHolder;
        keyInputManagerEvent.GameStartEvent.AddListener(KeyInputManageByState);
    }
    private void UnsubscribeFromEvent() {
        Debug.Log("Unsubscribed");
        if (keyInputManagerEvent != null) {
            keyInputManagerEvent.GameStartEvent.RemoveListener(KeyInputManageByState);
            keyInputManagerEvent = null;
        }
    }
    private void KeyInputManageByState(KeyCode code) {
        switch(gameData.NowGameState) {
            case GameState.GAMESTART :
                StateManage(GameState.INGAME_WALK);
                break;
            case GameState.INGAME_WALK :
                PlayerMoveController(code);
                break;
            case GameState.INGAME_TRADE :
                break;
            case GameState.INGAME_TALK :
                break;
            case GameState.GAMEENDING :
                break;
            case GameState.PAUSE :
                break;
            case GameState.GAMEOVER :
                break; 
            default:
                break;
        }
    }

    // walk
    private void PlayerMoveController(KeyCode code) {
        switch (code) {
            case KeyCode.W:
                playerControllerScript.PlayerMoveUp();
                break;
            case KeyCode.A:
                playerControllerScript.PlayerMoveLeft();
                break;
            case KeyCode.S:
                playerControllerScript.PlayerMoveDown();
                break;
            case KeyCode.D:
                playerControllerScript.PlayerMoveRight();
                break;
            default:
                break;
        }
    }

}
