using UnityEngine;

public class RotatingMenuObject : MonoBehaviour {
    [SerializeField] private bool rotateLeft;
    [SerializeField] private bool rotateRight;
    [SerializeField] private float speed;
    void Update() {
        if (rotateLeft) {
            transform.Rotate(new Vector3(0, 0, speed * Time.unscaledDeltaTime));
        }
        else {
            transform.Rotate(new Vector3(0, 0, -speed * Time.unscaledDeltaTime));
        }
    }
}
