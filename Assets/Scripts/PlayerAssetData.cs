public class PlayerAssetData {
    private float playerHold; // 現金
    private float stableAsset; //
    private float activeAsset;
    private float fxAsset;
    private float savingAsset;
    private float sumAsset;

    public float PlayerHold {
        get { return playerHold; }
        set { playerHold = value; }
    }
    public float StableAsset {
        get { return stableAsset; }
        set { stableAsset = value; }
    }
    public float ActiveAsset {
        get { return activeAsset; }
        set { activeAsset = value; }
    }
    public float FxAsset {
        get { return fxAsset; }
        set { fxAsset = value; }
    }
    public float SavingAsset {
        get { return savingAsset; }
        set { savingAsset = value; }
    }
    public float SumAsset {
        get { return sumAsset; }
        set { sumAsset = value; }
    }

    public PlayerAssetData() {
        playerHold = 1000f;
    }
}