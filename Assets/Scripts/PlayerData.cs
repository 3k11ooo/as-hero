using UnityEngine;

public class PlayerData {
    private Vector2 playerPos;
    private float holdMoney;

    public Vector2 PlayerPos {
        get { return playerPos; }
        set { playerPos = value; }
    }

    public float HoldMoney {
        get { return holdMoney; }
        set { holdMoney = value; }
    }

    public PlayerData (Vector2 pos) {
        playerPos = pos;
    }
}