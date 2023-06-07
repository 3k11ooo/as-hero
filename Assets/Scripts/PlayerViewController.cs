using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewController : MonoBehaviour {
    private Vector2 nowPlayerPos;

    public Vector2 NowPlayerPos {
        get { return nowPlayerPos; }
        set { nowPlayerPos = value; }
    }

    public void LoadPlayerViewPos() {
        nowPlayerPos = transform.position;
    }

    public void WritePlayerViewPos(Vector2 nowPos) {
        nowPlayerPos = nowPos;
        transform.position = nowPlayerPos;
    }
}