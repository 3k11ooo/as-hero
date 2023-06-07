using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour {
    //  参照しましょう
    [SerializeField] private GameObject keyInput; 
    [SerializeField] private GameObject viewController;
    [SerializeField] private PlayerController playerControllerScript;



    private GameData gameData = new GameData();
    private SceneManager sceneManager = new SceneManager();
    private GameState nowGameState;
    private SceneState nowSceneState;

    private void Awake() {
        DontDestroyOnLoad(this);
        nowGameState = gameData.NowGameState;
        nowSceneState = gameData.NowSceneState;
        SceneInitManagement();
    }


    public void GetKeyInput(KeyCode code) {
        // 管理
        // Debug.Log(code);
        
        switch (code) {
            case KeyCode.Space:
                // viewController.SwitchScene(sceneState+1);
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
        switch (nowSceneState) {
            case SceneState.HOME:
                playerControllerScript.init(new Vector2(3f, -3f));
                break;
        }
    }

    private void StateManage () {

    }
}
