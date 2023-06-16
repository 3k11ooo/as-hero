public class GameData {
    private GameState nowGameState;
    private SceneState nowSceneState;
    private TurnCount nowTurnCount;
    private string[] turnData = {
        "いち　ねんめ",
        "に　ねんめ",
        "さん　ねんめ",
        "よ　ねんめ",
        "ご　ねんめ",
        "ろく　ねんめ",
        "なな　ねんめ",
        "はち　ねんめ",
        "きゅう　ねんめ",
        "じゅう　ねんめ",
    };

    public GameState NowGameState {
        get { return nowGameState; }
        set { nowGameState = value; }
    }
    public SceneState NowSceneState {
        get { return nowSceneState; }
        set { nowSceneState = value; }
    }
    public TurnCount NowTurnCount {
        get { return nowTurnCount; }
        set { nowTurnCount = value; }
    }
    public string[] TurnData {
        get { return turnData; }
        set { turnData = value; }
    }

    public GameData() {
        nowGameState = GameState.GAMESTART;
        nowSceneState = SceneState.HOME;
        nowTurnCount = TurnCount.いちねんめ;
    }
}