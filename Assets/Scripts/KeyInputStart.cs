using UnityEngine;
using UnityEngine.Events;

public class KeyInputStart : KeyInputMapper {
    public UnityEvent<KeyCode> GameStartInputEvent = new UnityEvent<KeyCode>();

    public override void KeyManaged(KeyCode code) {
        if (code == KeyCode.Space) {
            Debug.Log("start game!!");
            GameStartInputEvent.Invoke(code);
        }
    }
}