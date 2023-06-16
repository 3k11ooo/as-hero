using UnityEngine;

public class ActiveAssetData : AssetData {
    private float returnRate;

    public ActiveAssetData(string name) : base(name, Asset.ACTIVE) {

    }
    public float CalReturn (float playerHold) {
        playerHold += GetPlayerReturn(playerHold, returnRate);
        return playerHold;
    }
    public string CalReturnRate() {
        returnRate = GetReturnRate(returnRate);
        // Debug.Log(GetName() + "return rate : " + returnRate);
        float num = returnRate * 100;
        return num.ToString("#.##;{#.##;0");
    }

}