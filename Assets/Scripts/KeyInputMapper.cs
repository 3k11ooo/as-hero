using UnityEngine;
public abstract class KeyInputMapper {
    // FIXME: アブストラクトのクラスを作成して、keyinputのクラスを複数作成し、GameManagerで分岐で処理させる
    public abstract void KeyManaged(KeyCode code);
}