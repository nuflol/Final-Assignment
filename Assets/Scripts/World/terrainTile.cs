using System.Collections.Generic;
using UnityEngine;

public class terrainTile : MonoBehaviour
{
    [SerializeField] private Vector2Int tilePosition;
    [SerializeField] private List<SpawnObject> spawnObjects;
    void Start()
    {
        GetComponentInParent<WorldScrolling>().Add(gameObject, tilePosition);

        transform.position = new Vector3(-100, -100, 0);
    }

    public void Spawn() {
        for (int i = 0; i < spawnObjects.Count; i++) {
            spawnObjects[i].Spawn();
        }
    }
}
