using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour {
    [SerializeField] private GameObject panel;
    [SerializeField] private List<UpgradeButton> upgradeButtons;
    private PauseManager _pauseManager;

    private void Awake() {
        _pauseManager = GetComponent<PauseManager>();
    }

    private void Start() {
        HideButtons();
    }

    public void Clean() {
        for (int i = 0; i < upgradeButtons.Count; i++) {
            upgradeButtons[i].Clean();
        }
    }

    public void OpenPanel(List<UpgradeData> upgradeDatas) {
        Clean();
        _pauseManager.PauseGame();
        panel.SetActive(true);
        for (int i = 0; i < upgradeDatas.Count; i++) {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }

    public void Upgrade(int pressedButtonID) {
        GameManager.Instance.playerTransform.GetComponent<Level>().Upgrade(pressedButtonID);
        ClosePanel();
    }
    
    public void ClosePanel() {
        HideButtons();
        _pauseManager.UnPauseGame();
        panel.SetActive(false);
    }
    private void HideButtons() {

        for (int i = 0; i < upgradeButtons.Count; i++) {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }
}
