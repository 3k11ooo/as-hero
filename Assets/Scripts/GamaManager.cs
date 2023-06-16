using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GamaManager : MonoBehaviour {
    //  参照しましょう
    [SerializeField] private KeyInput keyInputScript; 
    [SerializeField] private ViewController viewControllerScript;
    [SerializeField] private SceneManager sceneManagerScript;
    [SerializeField] private PlayerController playerControllerScript;
    [SerializeField] private TradeManager tradeManagerScript;
    [SerializeField] private KeyInputManager keyInputManager;
    [SerializeField] private KeyInputManager keyInputManagerEvent;
    [SerializeField] private UiManager uiManagerScript;
    [SerializeField] private Tilemap tilemap;



    private GameData gameData = new GameData();
    private GameState overlapNextState;
    private bool overlap;
    private bool isOnce = false;
    private int turnCount = 0;

    private void Awake() {
        DontDestroyOnLoad(this);
        SceneInitManagement();
        initTradeTextData();
        // StateManage(GameState.INGAME_TRADE);
        StateManage(GameState.GAMESTART);
        SubscribeToEvent(keyInputManagerEvent);
        keyInputManager.initKeyInputManager();
    }

    // update
    public void GameManagerUpdate(KeyCode code) {
        // 管理
        switch(gameData.NowGameState) {
            case GameState.GAMESTART :
                keyInputManager.StartGame(code);
                break;
            case GameState.INGAME_WALK :
                overlap = OverlapCheck();
                keyInputManager.Walk(code);
                break;
            case GameState.INGAME_TRADE :
                keyInputManager.Trade(code);
                break;
            case GameState.INGAME_TALK :
                break;
            case GameState.GAMEENDING :
                break;
            case GameState.PAUSE :
                break;
            case GameState.GAMEOVER :
                break; 
            case GameState.INGAME_TURNEND :
                break;
            default:
                break;
        }
    }

    // Scene管理
    private void SceneInitManagement() {
        switch (gameData.NowSceneState) {
            case SceneState.HOME:
                playerControllerScript.init(new Vector2(-3.7f, 0.5f));
                break;
        }
        Debug.Log(gameData.NowSceneState);
    }
    // state 管理
    private void StateManage(GameState nextState) {
        gameData.NowGameState = nextState;
        uiManagerScript.ManageUI(gameData.NowGameState);
        uiManagerScript.TurnViewController(turnCount, gameData.TurnData);
        Debug.Log(gameData.NowGameState);
    }

    // 取引の画面管理
    private void initTradeTextData() {
        tradeManagerScript.init();
    }

    // playerとオブジェクトの重なり判定
    private bool OverlapCheck() {
        Vector3Int cellPosition = tilemap.WorldToCell(playerControllerScript.PlayerData.PlayerPos);

        TileBase tile = tilemap.GetTile(cellPosition);
        switch (cellPosition.y)
        {
            case 3:
                uiManagerScript.InGameUIControl(tile, "しんぶんをみる");
                overlapNextState = GameState.INGAME_TALK;
                break;
            case -3:
                uiManagerScript.InGameUIControl(tile, "パソコンをみる");
                overlapNextState = GameState.INGAME_TRADE;
                break;
            case 0 :
                uiManagerScript.InGameUIControl(tile, "ねる");
                overlapNextState = GameState.INGAME_TURNEND;
                break;
            default:
                uiManagerScript.InGameUIControl(tile, "");
                overlapNextState = GameState.INGAME_WALK;
                break;
        }
        return tile;
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
    // event invoke
    private void KeyInputManageByState(KeyCode code) {
        switch(gameData.NowGameState) {
            case GameState.GAMESTART :
                StateManage(GameState.INGAME_WALK);
                break;
            case GameState.INGAME_WALK :
                PlayerMoveController(code);
                break;
            case GameState.INGAME_TRADE :
                if (isOnce == false) {
                    StartCoroutine( TradeInput(code) ); 
                }
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

    // walk input
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
            case KeyCode.Space:
                if (overlap == true && overlapNextState == GameState.INGAME_TURNEND) {
                    StartCoroutine("TurnEnd"); 
                }
                else if (overlap == true) {
                    StateManage(overlapNextState);
                }
                break;
            default:
                break;
        }
    }
    // turn end input
    private void OnceInput() {
        if (isOnce == false) {
            isOnce = true;
        }
    }
    IEnumerator TurnEnd() {
        //終わるまで待ってほしい処理を書く
        StateManage(GameState.INGAME_TURNEND);
        OnceInput();
        turnCount++;
        uiManagerScript.TurnEndViewControl(true);
        tradeManagerScript.ChangeReturnRate();
        tradeManagerScript.ChangePlayerHold();
    
        //3秒待つ
        yield return new WaitForSeconds(3);
    
        //再開してから実行したい処理を書く
        isOnce = false;
        StateManage(GameState.INGAME_WALK);
        uiManagerScript.TurnEndViewControl(false);
    } 

    // trade input
    IEnumerator TradeInput(KeyCode code) {
        // wait by end
        OnceInput();
        yield return new WaitForSeconds(0.5f);

        // do after wait
        isOnce = false;
        tradeManagerScript.PlayerTradeController(code);
    }
    public void EndTrade() {
        StateManage(GameState.INGAME_WALK);
    }
}
