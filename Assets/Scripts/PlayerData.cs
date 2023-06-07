using UnityEngine;

public class PlayerData {
    private Vector2 playerPos;

    public Vector2 PlayerPos {
        get { return playerPos; }
        set { playerPos = value; }
    }

    public PlayerData (Vector2 pos) {
        playerPos = pos;
    }
}