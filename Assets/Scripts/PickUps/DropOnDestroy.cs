using UnityEngine;
using System.Collections.Generic;

public class DropOnDestroy : MonoBehaviour {
    [SerializeField] private List<GameObject> dropItemPrefab;
    [SerializeField] [Range(0f,1f)] float chance = 1f;

    private bool _isQuiting;

    private void OnApplicationQuit() {
        _isQuiting = true;
    }
    public void CheckDrop() {
        if (_isQuiting) { return; } // Will ignore Instantiate if the object is being destroyed by quitting the game

        // Null check
        if (dropItemPrefab.Count <= 0) {
            Debug.LogWarning("List of drop items is empty!"); 
            return; }

        if (Random.value < chance) {
            GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)];
            
            // Null check
            if (toDrop == null) { Debug.LogWarning("DropOnDestroy, The reference to dropped item is null, check prefab of breakable object!");
                return; }
            
            SpawnManager.Instace.SpawnObject(transform.position, toDrop);
        }
    }
}
