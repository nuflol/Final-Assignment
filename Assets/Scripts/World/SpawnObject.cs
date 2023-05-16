using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObject : MonoBehaviour {
    [SerializeField] private GameObject toSpawn;
    [SerializeField] [Range(0f, 1f)] private float probability;

    public void Spawn() {
        if (Random.value < probability) {
            SpawnManager.Instace.SpawnObject(transform.position, toSpawn);
        }
    }
}
