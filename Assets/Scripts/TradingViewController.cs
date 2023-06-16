using UnityEngine;
using TMPro;

public class TradingViewController : MonoBehaviour {
    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private TMPro.TMP_Text _error;

    private void Start() {
        // text.SetText("はろーわーるど！");
    }

    public void ChangeViewText(string textData) {
        _text.SetText(textData);
    }
    public void ViewErrorText(bool error) {
        if (error == true) {
            _text.SetText("");
            _error.SetText("この　とりひき　は　できません。\nやりなおしてください。\n\nスペースキー　で　やりなおしできます。");
        }
        else {
            _error.SetText("");
        }
    }
}