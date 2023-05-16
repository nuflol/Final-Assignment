using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour {
    private int _xp = 0;
    private int _lvl = 1;

    [SerializeField] private XPBar xpBar;
    [SerializeField] private UpgradePanelManager upgradePanel;
    
    private List<UpgradeData> _selectedUpgrades;
    [SerializeField] private List<UpgradeData> upgrades;
    [SerializeField] private List<UpgradeData> acquiredUpgrades;

    private WeaponManager _weaponManager;
    private PassiveItems _passiveItems;

    [SerializeField] private List<UpgradeData> upradesAvailableOnStart;

    int TO_LEVEL_UP { get { return _lvl * 1000; } }

    private void Awake() {
        _weaponManager = GetComponent<WeaponManager>();
        _passiveItems = GetComponent<PassiveItems>();
    }

    private void Start() {
        xpBar.UpdateXPSlider(_xp, TO_LEVEL_UP);
        xpBar.SetLevelText(_lvl);
        AddUpgradesIntoListOfAvailableUpgrades(upradesAvailableOnStart);
    }

    public void AddXP(int amount) {
        _xp += amount;
        CheckLevelUp();
        xpBar.UpdateXPSlider(_xp, TO_LEVEL_UP);
    }

    public void Upgrade(int selectedUpgradeID) {
        UpgradeData upgradeData = _selectedUpgrades[selectedUpgradeID];
        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

        switch (upgradeData.UpgradeType) {
            case UpgradeType.WeaponUpgrade:
                _weaponManager.UpgradeWeapon(upgradeData);
                break;
            case UpgradeType.ItemUpgrade:
                _passiveItems.UpgradeItem(upgradeData);
                break;
            case UpgradeType.WeaponGet:
                _weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemGet:
                _passiveItems.Equip(upgradeData.item);
                AddUpgradesIntoListOfAvailableUpgrades(upgradeData.item.upgrades);
                break;
        }
        
        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }
    
    public void CheckLevelUp() {
        if (_xp >= TO_LEVEL_UP) {
            LevelUp();
        }
    }
    private void LevelUp() {
        if (_selectedUpgrades == null) { _selectedUpgrades = new List<UpgradeData>(); }
        _selectedUpgrades.Clear();
        _selectedUpgrades.AddRange(GetUpgrades(5));
        
        upgradePanel.OpenPanel(_selectedUpgrades);
        _xp -= TO_LEVEL_UP;
        _lvl += 1;
        xpBar.SetLevelText(_lvl);
    }

    public List<UpgradeData> GetUpgrades(int count) {
        List<UpgradeData> upgradeList = new List<UpgradeData>();
        if (count > upgrades.Count) { count = upgrades.Count; }
        for (int i = 0; i < count; i++) {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }
        
        return upgradeList;
    }
    internal void AddUpgradesIntoListOfAvailableUpgrades(List<UpgradeData> upgradesToAdd) {
        if (upgradesToAdd == null) { return; }
        this.upgrades.AddRange(upgradesToAdd);
    }
}
