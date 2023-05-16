using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour {
   private float _timeToDisable = 0.2f;
   private float _timer;

   private void OnEnable() {
      _timer = _timeToDisable;
   }

   private void LateUpdate() {
      _timer -= Time.deltaTime;
      if (_timer < 0f) {
         gameObject.SetActive(false);
      }
   }
}
