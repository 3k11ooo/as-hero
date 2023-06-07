public class GameData {
    private GameState nowGameState;
    private SceneState nowSceneState;

    public GameState NowGameState {
        get { return nowGameState; }
        set { nowGameState = value; }
    }
    public SceneState NowSceneState {
        get { return nowSceneState; }
        set { nowSceneState = value; }
    }

    public GameData() {
        nowGameState = GameState.GAMESTART;
        nowSceneState = SceneState.HOME;
    }
}