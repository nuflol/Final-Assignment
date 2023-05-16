using UnityEngine;

public class ShurikenRotate : MonoBehaviour {
    void Update() {
        transform.Rotate(new Vector3(0, 0, 550 * Time.deltaTime));
    }
}
