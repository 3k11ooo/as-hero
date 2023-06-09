using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour {
    //  参照しましょう
    [SerializeField] private KeyInput keyInputScript; 
    [SerializeField] private ViewController viewControllerScript;
    [SerializeField] private SceneManager sceneManagerScript;
    [SerializeField] private PlayerController playerControllerScript;
    [SerializeField] private TradeManager tradeManagerScript;



    private GameData gameData = new GameData();

    private void Awake() {
        DontDestroyOnLoad(this);
        SceneInitManagement();
        initTradeTextData();
        keyInputScript.NowGameState = GameState.GAMESTART;
    }


    public void GetKeyInput(KeyCode code) {
        // 管理
        // Debug.Log(code);
        switch (code) {
            case KeyCode.Space:
                if(gameData.NowGameState == GameState.GAMESTART) {
                    StateManage(GameState.INGAME_WALK);
                }
                else if(gameData.NowGameState == GameState.INGAME_TALK || gameData.NowGameState == GameState.INGAME_TRADE) {
                    tradeManagerScript.ChangeViewTextData();
                }
                break;
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


    private void SceneInitManagement() {
        switch (gameData.NowSceneState) {
            case SceneState.HOME:
                playerControllerScript.init(new Vector2(3f, -3f));
                break;
        }
    }

    private void StateManage(GameState nextState) {
        gameData.NowGameState = nextState;
        keyInputScript.NowGameState = gameData.NowGameState;
    }

    // 取引の顔面管理
    private void initTradeTextData() {
        tradeManagerScript.LoadTextData("tradeBrand");
    }
}
