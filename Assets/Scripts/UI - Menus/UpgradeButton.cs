using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {
    [SerializeField] Image upgradeIcon;

    public void Set(UpgradeData upgradeData) {
        upgradeIcon.sprite = upgradeData.icon;
    }

    internal void Clean() {
        upgradeIcon.sprite = null;
    }
}
