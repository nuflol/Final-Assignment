using System;
using UnityEngine;

public class DamageMessage : MonoBehaviour {
    private float ttl = 2f;
    [SerializeField] private float timeToLeave = 2f;

    private void OnEnable() {
        ttl = timeToLeave;
    }
    private void Update() {
        ttl -= Time.deltaTime;
        if (ttl < 0f) {
            gameObject.SetActive(false);
        }
    }
}
