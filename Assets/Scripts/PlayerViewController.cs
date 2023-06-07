using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewController : MonoBehaviour {
    private Vector2 nowPlayerPos;

    public Vector2 NowPlayerPos {
        get { return nowPlayerPos; }
        set { nowPlayerPos = value; }
    }
    
    private void Awake() {
        LoadPlayerViewPos();
        Debug.Log(nowPlayerPos);
    }

    public void LoadPlayerViewPos() {
        nowPlayerPos = transform.position;
    }

    public void WritePlayerViewPos() {
        transform.position = nowPlayerPos;
    }
}