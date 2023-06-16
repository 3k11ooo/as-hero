using UnityEngine;

public class SavingAssetData : AssetData {
    private float returnRate;

    public SavingAssetData(string name) : base(name, Asset.SAVING) {
        
    }
    public float CalReturn (float playerHold) {
        playerHold += GetPlayerReturn(playerHold, returnRate);
        return playerHold;
    }
    public string CalReturnRate() {
        returnRate = GetReturnRate(returnRate);
        // Debug.Log(GetName() + "return rate : " + returnRate);
        float num = returnRate * 100;
        return num.ToString("0.####;{0.####;0");
    }

}