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
    }

    private void WritePlayerData() {
        playerData.PlayerPos = playerVector2;
        playerViewControllerScript.WritePlayerViewPos(playerVector2);
        // Debug.Log(playerVector2);
    }

    public void PlayerMoveUp() {
        // Debug.Log("up");
        if (playerVector2.y < 4.65f) {
            playerVector2.y += 0.1f;
        }
        WritePlayerData();
    }
    
    public void PlayerMoveLeft() {
        // Debug.Log("left");
        if (playerVector2.x > -6.4f) {
            playerVector2.x -= 0.1f;
        }
        WritePlayerData();
    }

    public void PlayerMoveDown() {
        // Debug.Log("down");
        if (playerVector2.y > -4.65f) {
            playerVector2.y -= 0.1f;
        }
        WritePlayerData();
    }

    public void PlayerMoveRight() {
        // Debug.Log("right");
        if (playerVector2.x < 6.4f) {
            playerVector2.x += 0.1f;
        }  
        WritePlayerData();     
    }
}