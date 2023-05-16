using System;
using UnityEngine;

public class PlayerWinManager : MonoBehaviour {
    [SerializeField] private GameObject winGamePanel;
    [SerializeField] private DataContainer dataContainer;
    private PauseManager _pauseManager;

    private void Start() {
        _pauseManager = GetComponent<PauseManager>();
    }
    public void Win() {
        winGamePanel.SetActive(true);
        _pauseManager.PauseGame();
        dataContainer.StageComplete(0);
    }
}
