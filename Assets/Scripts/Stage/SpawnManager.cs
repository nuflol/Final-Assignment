using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public static SpawnManager Instace;

    private void Awake() {
        Instace = this;
    }

    public void SpawnObject(Vector3 worldPosition, GameObject toSpawn) {
        Transform t = Instantiate(toSpawn, transform).transform;
        t.position = worldPosition;
    }
}
