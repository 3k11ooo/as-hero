using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private GameObject playerViewController;

    private PlayerData playerData; 
    
    private PlayerViewController playerViewControllerScript;
    private Vector2 playerVector2; 

    public PlayerData PlayerData {
        get { return playerData; }
        set { playerData = value; }
    }

    private void Awake() {
        playerData = new PlayerData();
        playerViewControllerScript = playerViewController.GetComponent<PlayerViewController>();
         // playerVector2 = this.playerData.PlayerPos;
    }

    public void init() {
        // playerVector2 = playerViewControllerScript.NowPlayerPos;
        Debug.Log(playerViewControllerScript);
        Debug.Log(playerVector2);
    }

    private void WritePlayerData() {
        Debug.Log(playerVector2);
        // playerData.PlayerPos = playerVector2;
        // Debug.Log(playerViewControllerScript.NowPlayerPos);
        // playerViewControllerScript.NowPlayerPos = playerVector2;
    }

    public void PlayerMoveUp() {
        Debug.Log(playerVector2);
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