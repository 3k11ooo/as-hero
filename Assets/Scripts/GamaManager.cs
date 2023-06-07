using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour {
    //  参照しましょう
    [SerializeField] private GameObject keyInput; 
    [SerializeField] private GameObject viewController;
    [SerializeField] private GameObject playerController;


    private GameData gameData = new GameData();
    private SceneState sceneState = new SceneState();
    private GameState nowGameState;
    private PlayerController playerControllerScript;
    
    



    private void Awake() {
        DontDestroyOnLoad(this);
        Debug.Log(gameData.NowGameState);
        nowGameState = gameData.NowGameState;
        playerControllerScript = playerController.GetComponent<PlayerController>();
        playerControllerScript.init();
    }


    public void GetKeyInput(KeyCode code) {
        Debug.Log(playerControllerScript);
        // 管理
        // Debug.Log(code);
        // Debug.Log(playerControllerScript.PlayerData.PlayerPos);
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
}
