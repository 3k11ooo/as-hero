using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyInput : MonoBehaviour {
    public UnityEvent<KeyCode> unityEvent = new UnityEvent<KeyCode>();
    private bool keyDown = false;
    private KeyCode nowKeyDownCode;
    private GameState nowGameState; 

    public bool KeyDown {
        get { return keyDown; }
        set { keyDown = value; } 
    } 

    public GameState NowGameState {
        get { return nowGameState; }
        set { nowGameState = value; }
    }   



    private void Update() {
        switch (nowGameState) {
            case GameState.GAMESTART:
                ChangeTextData();
                break;
            case GameState.INGAME_WALK:
                PlayerMoveKeyInput();
                break;
            case GameState.INGAME_TRADE:
                ChangeTextData();
                break;
            default:
                break;
        }
    }

    private void PlayerMoveKeyInput() {
        if (Input.anyKey && unityEvent != null) {
            foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode))) {
                // 入力されているか
                if (Input.GetKeyDown(code) && nowKeyDownCode == KeyCode.None) {
                    keyDown = true;
                    nowKeyDownCode = code;
                }
                else if (Input.GetKeyDown(code) && nowKeyDownCode != code) {
                    keyDown = true;
                    nowKeyDownCode = code;
                }
                else if (Input.GetKeyUp(code) && nowKeyDownCode == code) {
                    keyDown = false;
                    nowKeyDownCode = KeyCode.None;
                }
            }
        }
        else if (!Input.anyKey && unityEvent != null && keyDown == true) {
            foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode))) {
                // 入力が解除されたか
                if (Input.GetKeyUp(code) && nowKeyDownCode == code) {
                    keyDown = false;
                    nowKeyDownCode = KeyCode.None;
                }
            }
        }

        if (keyDown == true && nowKeyDownCode != KeyCode.None) {
            unityEvent.Invoke(nowKeyDownCode);
        }
    }

    private void ChangeTextData() {
        if(Input.GetKeyDown(KeyCode.Space) && unityEvent != null) {
            unityEvent.Invoke(KeyCode.Space);
        }
    }
    private void ChangeSceneState() {
        if(Input.GetKeyDown(KeyCode.Space) && unityEvent != null) {
            unityEvent.Invoke(KeyCode.Space);
        }
    }
}   