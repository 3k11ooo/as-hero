using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private PlayerViewController playerViewControllerScript;


    private PlayerData playerData; 
    private Vector2 playerVector2; 

    public PlayerData PlayerData {
        get { return playerData; }
        set { playerData = value; }
    }

    public void init(Vector2 pos) {
        playerData = new PlayerData(pos);
        playerVector2 = playerData.PlayerPos;
        playerViewControllerScript.NowPlayerPos = playerVector2;
        playerViewControllerScript.WritePlayerViewPos(playerVector2);
        Debug.Log(playerVector2);
    }

    private void WritePlayerData() {
        playerData.PlayerPos = playerVector2;
        playerViewControllerScript.WritePlayerViewPos(playerVector2);
        // Debug.Log(playerVector2);
    }

    public void PlayerMoveUp() {
        // Debug.Log("up");
        playerVector2.y += 0.01f;
        WritePlayerData();
    }
    
    public void PlayerMoveLeft() {
        // Debug.Log("left");
        playerVector2.x -= 0.01f;
        WritePlayerData();
    }

    public void PlayerMoveDown() {
        // Debug.Log("down");
        playerVector2.y -= 0.01f;
        WritePlayerData();
    }

    public void PlayerMoveRight() {
        // Debug.Log("right");
        playerVector2.x += 0.01f;   
        WritePlayerData();     
    }
}