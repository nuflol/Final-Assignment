using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour {
    [SerializeField] private GameObject panel;
    private PauseManager _pauseManager;

    private void Awake() {
        _pauseManager = GetComponent<PauseManager>();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (panel.activeInHierarchy == false) {
                OpenMenu();
            }
            else {
                CloseMenu();
            }
        }
    }

    public void CloseMenu() {
        _pauseManager.UnPauseGame();
        panel.SetActive(false);
    }
    
    public void OpenMenu() {
        _pauseManager.PauseGame();
        panel.SetActive(true);
    }
}
