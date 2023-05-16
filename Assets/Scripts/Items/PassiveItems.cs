using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PassiveItems : MonoBehaviour {
    [SerializeField] private List<Item> items;

    private Character _character;
    private void Awake() {
        _character = GetComponent<Character>();
    }

    public void Equip(Item itemToEquip) {
        if (items == null) { items = new List<Item>(); }
        
        Item newItemInstance = new Item();
        newItemInstance.Init(itemToEquip.Name);
        newItemInstance.stats.Sum(itemToEquip.stats);
        
        items.Add(newItemInstance);
        newItemInstance.Equip(_character);
    }

    public void UnEquip(Item itemToUnEquip) {
        
    }
    
    internal void UpgradeItem(UpgradeData upgradeData) {
        Item itemToUpgrade = items.Find(id => id.Name == upgradeData.item.Name);
        itemToUpgrade.UnEquip(_character);
        itemToUpgrade.stats.Sum(upgradeData.itemStats);
        itemToUpgrade.Equip(_character);
    }
}
