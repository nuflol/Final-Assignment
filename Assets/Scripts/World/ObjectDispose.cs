using System;
using UnityEngine;

public class ObjectDispose : MonoBehaviour {
    private Transform _playerTransform;
    private float _maxDistance = 35f;

    private void Start() {
        _playerTransform = GameManager.Instance.playerTransform;
    }
    private void Update() {
        float distance = Vector3.Distance(transform.position, _playerTransform.position);
        if (distance > _maxDistance) {
            Destroy(gameObject);
        }
    }
}
