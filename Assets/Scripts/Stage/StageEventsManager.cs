using System;
using UnityEngine;

public class StageEventsManager : MonoBehaviour {
    [SerializeField] private StageData stageData;
    [SerializeField] private EnemyManager enemyManager;

    private StageTime _stageTime;
    private int _eventIndexer;
    private PlayerWinManager _playerWinManager;

    private void Awake() {
        _stageTime = GetComponent<StageTime>();
    }

    private void Start() {
        _playerWinManager = FindObjectOfType<PlayerWinManager>();
    }

    private void Update() {
        if (_eventIndexer >= stageData.stageEvents.Count) {
            return;
        }

        if (_stageTime.time > stageData.stageEvents[_eventIndexer].time) {
            switch (stageData.stageEvents[_eventIndexer].eventType) {
                case StageEventType.SpawnEnemy:
                    SpawnEnemy(false);
                    break;

                case StageEventType.SpawnObject:
                    SpawnObject();
                    break;

                case StageEventType.WinStage:
                    WinStage();
                    break;
               
                case StageEventType.SpawnEnemyBoss:
                    SpawnEnemyBoss();
                    
                    break;
            }

            // Debug.Log(stageData.stageEvents[_eventIndexer].message);
            _eventIndexer += 1;
        }
    }
    private void SpawnEnemyBoss() {
        SpawnEnemy(true);
    }

    private void WinStage() {
        _playerWinManager.Win();
    }

    private void SpawnEnemy(bool bossEnemy) {
        for (int i = 0; i < stageData.stageEvents[_eventIndexer].count; i++) {
            enemyManager.SpawnEnemy(stageData.stageEvents[_eventIndexer].enemyToSpawn, bossEnemy);      
        }
    }

    private void SpawnObject() {
        for (int i = 0; i < stageData.stageEvents[_eventIndexer].count; i++) {
            // Generate and save random positions in a square pattern around player
            Vector3 positionToSpawn = GameManager.Instance.playerTransform.position;
            positionToSpawn += UtilityTools.GenerateRandomPositionSquarePattern(new Vector2(5f, 5f));

            // Spawn object in generated positions
            SpawnManager.Instace.SpawnObject(positionToSpawn, stageData.stageEvents[_eventIndexer].objectToSpawn);
        }
    }
}
