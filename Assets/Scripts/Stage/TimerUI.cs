using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour {
    private TextMeshProUGUI _text;

    private void Awake() {
        _text = GetComponent<TextMeshProUGUI>();
    }
    
    public void UpdateTime(float time) {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);
        _text.text = minutes.ToString() + ":" + seconds.ToString("00"); 
    }
}
