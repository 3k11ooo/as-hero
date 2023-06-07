using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyInput : MonoBehaviour {
    public UnityEvent<KeyCode> unityEvent = new UnityEvent<KeyCode>();


    private void Update() {
        if (Input.anyKey && unityEvent != null) {

            foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode))) {
                if (Input.GetKeyDown(code)) {
                    unityEvent.Invoke(code);
                }
            }
        }
    }
}   