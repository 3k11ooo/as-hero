using UnityEngine;
public enum Asset {
    STABLE,
    ACTIVE,
    FX,
    SAVING
}

public abstract class AssetData {
    private string assetName;
    private int playerTotalHolding;
    private float[] returnRange; // max min

    public AssetData(string name, Asset asset) {
        this.assetName = name;
        switch (asset) {
            case Asset.STABLE:
                this.returnRange = new float[2]{
                    0.3f,
                    -0.06f
                };
                break;
            case Asset.ACTIVE:
                this.returnRange = new float[2]{
                    1.0f,
                    -0.2f
                };
                break;
            case Asset.FX:
                this.returnRange = new float[2]{
                    3.0f,
                    -1.0f
                };
                break;
            case Asset.SAVING:
                this.returnRange = new float[2]{
                    0.001f,
                    0.001f
                };
                break;
            default:
                break;
        }
    }

    // public abstract void CalReturnRate();

    public float GetReturnRate(float beforeRate) {
        int rand = Random.Range(1, 0);
        if (rand == 0) {
            float returnRate = Random.Range(returnRange[0], beforeRate);
            return returnRate;
        }
        else {
            float returnRate = Random.Range(beforeRate, returnRange[1]);
            return returnRate;
        }
    }
    public float GetPlayerReturn(float playerHold, float returnRate) {
        return playerHold * returnRate;
    }
    public string GetName() {
        return assetName;
    }
}