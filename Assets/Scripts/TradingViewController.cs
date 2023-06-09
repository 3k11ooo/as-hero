using UnityEngine;
using TMPro;

public class TradingViewController : MonoBehaviour {
    [SerializeField] private TMPro.TMP_Text text;
    [SerializeField] private TextMeshProUGUI test;

    private void Start() {
        // text.SetText("はろーわーるど！");
    }

    public void ChangeViewText(string textData) {
        text.SetText(textData);
    }
}