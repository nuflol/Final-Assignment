using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator _animator;

    
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
    }
}
