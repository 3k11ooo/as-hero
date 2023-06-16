using UnityEngine;

public class ActiveAssetData : AssetData {
    private float returnRate;

    public ActiveAssetData(string name) : base(name, Asset.STABLE) {

    }
    public float CalReturn (float playerHold) {
        playerHold += GetPlayerReturn(playerHold, returnRate);
        Debug.Log(GetName() + "player return : " + playerHold);
        return playerHold;
    }
    public string CalReturnRate() {
        returnRate = GetReturnRate(returnRate);
        // Debug.Log(GetName() + "return rate : " + returnRate);
        return returnRate.ToString("f1");
    }

}