using System;
using UnityEngine;

public class StageProgress : MonoBehaviour {
    private StageTime _stageTime;
    private void Awake() {
        _stageTime = GetComponent<StageTime>();
    }

    [SerializeField] private float progressTimeRate;
    [SerializeField] private float progressPerSplit;

    public float Progress {
        get { return 1f + _stageTime.time / progressTimeRate * progressPerSplit; }
    }

    private void FixedUpdate() {
        
    }
}
