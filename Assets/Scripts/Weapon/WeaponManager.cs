using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    [SerializeField] private Transform weaponObjectsContainer;
    [SerializeField] private WeaponData startingWeapon;

    private List<WeaponBase> _weapons;

    private void Awake() {
        _weapons = new List<WeaponBase>();
    }

    private void Start() {
        AddWeapon(startingWeapon);
    }
    public void AddWeapon(WeaponData weaponData) {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();
        weaponBase.SetData(weaponData);
        _weapons.Add(weaponBase);
        
        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);
        Level level = GetComponent<Level>();
        if (level == null) {
            level.AddUpgradesIntoListOfAvailableUpgrades(weaponData.upgrades);
        }
    }
    public void UpgradeWeapon(UpgradeData upgradeData) {
        WeaponBase weaponToUpgrade = _weapons.Find(wepData => wepData.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
