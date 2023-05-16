using UnityEngine;
using TMPro;

public class StageTime : MonoBehaviour {
    public float time;
    private TimerUI _timerUI;

    private void Awake() {
        _timerUI = FindObjectOfType<TimerUI>();
    }

    private void Update() {
        time += Time.deltaTime;
        _timerUI.UpdateTime(time);
    }
}
