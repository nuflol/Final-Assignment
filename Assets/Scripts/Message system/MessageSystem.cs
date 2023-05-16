using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class MessageSystem : MonoBehaviour {
    public static MessageSystem Instance;
    
    [SerializeField] private GameObject damageMessage;
    private List<TextMeshPro> _messagePool;
    private int _objectCount = 10;
    private int _count;
    
    private void Awake() {
        Instance = this;
    }

    private void Start() { 
        _messagePool = new List<TextMeshPro>();
        for (int i = 0; i < _objectCount; i++) {
            Populate();
        }
    }

    public void Populate() {
        GameObject go = Instantiate(damageMessage, transform);
        _messagePool.Add(go.GetComponent<TextMeshPro>());
        go.SetActive(false);
    }
    
    public void PostMessage(string text, Vector3 worldPos) {
        _messagePool[_count].gameObject.SetActive(true);
        _messagePool[_count].transform.position = worldPos;
        _messagePool[_count].text = text;
        _count += 1;

        if (_count >= _objectCount) {
            _count = 0;
        }
        // go.transform.position = worldPos;
        // go.GetComponent<TextMeshPro>().text = text;
    }
}
