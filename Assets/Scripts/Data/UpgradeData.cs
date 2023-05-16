using UnityEngine;
using UnityEngine.Serialization;

public enum UpgradeType {
    WeaponUpgrade,
    ItemUpgrade,
    WeaponGet,
    ItemGet
}
[CreateAssetMenu]
public class UpgradeData : ScriptableObject {
    public UpgradeType UpgradeType;
    public string Name;
    public Sprite icon;
    
    public WeaponData weaponData;
    public WeaponStats weaponUpgradeStats;

    public Item item;
    public ItemStats itemStats;
}
