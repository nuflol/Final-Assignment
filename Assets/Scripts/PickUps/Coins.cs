using System;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour {
    [SerializeField] private DataContainer data;
    [SerializeField] private TextMeshProUGUI coinCountText;

    private void Start() {
        
    }
    public void Add(int count) {
        data.coins += count;
        coinCountText.text = data.coins.ToString();
    }
}
