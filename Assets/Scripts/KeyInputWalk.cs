using UnityEngine;
public class KeyInputWalk : KeyInputMapper {
    [SerializeField] private KeyInput keyInputScript;

    protected override void KeyManaged() {
        Debug.Log("walk!");
    }
}