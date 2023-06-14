using UnityEngine;
using UnityEngine.Events;

public class KeyInputManager : MonoBehaviour  {
    private KeyInputStart start = new KeyInputStart();
    private KeyInputWalk walk = new KeyInputWalk();
    private int count;

    public UnityEvent<KeyCode> GameStartEvent = new UnityEvent<KeyCode>();

    public void initKeyInputManager() {
        // SubscribeToStartGameEvent(start);
        
        count = 0;
    }

    public void StartGame(KeyCode code) {
        if (count == 0 && code == KeyCode.Space) {
            // start.KeyManaged(code);
            GameStartEvent.Invoke(code);
            count++;
        }
    }
    public void Walk(KeyCode code) {
        if (code == KeyCode.W || code == KeyCode.A || code == KeyCode.S || code == KeyCode.D) {
            // walk.KeyManaged(code);
            GameStartEvent.Invoke(code);
        }
    }
    public void Trade(KeyCode code) {

    }


// 使ってない残骸
    // start
    // private void SubscribeToStartGameEvent(KeyInputStart eventHolder) {
    //     this.start = eventHolder;
    //     start.GameStartInputEvent.AddListener(SendKeyCodeToGameManager);
    // }
    // private void UnsubscribeFromEvent() {
    //     if (start != null) {
    //         start.GameStartInputEvent.RemoveListener(SendKeyCodeToGameManager);
    //         start = null;
    //     }
    // }
    
    // trade



    // all
    // private void SendKeyCodeToGameManager(KeyCode code) {
    //     GameStartEvent.Invoke(code);
    // }
}