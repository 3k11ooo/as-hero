using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyInput : MonoBehaviour {
    public UnityEvent<KeyCode> unityEvent = new UnityEvent<KeyCode>();
    private bool keyDown = false;
    private KeyCode nowKeyDownCode;

    public bool KeyDown {
        get { return keyDown; }
        set { keyDown = value; } 
    } 
    private void Update() {
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
}   