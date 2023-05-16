using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class EnemyManager : MonoBehaviour {
    [SerializeField] private StageProgress stageProgress;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnTimer;
    private GameObject _player;

    private List<Enemy> _bossEnemyList;
    private int _totalBossHp;
    private int _currentBossHp;
    [SerializeField] private Slider bossHealthBar;

    private void Start() {
        _player = GameManager.Instance.playerTransform.gameObject;
        bossHealthBar = FindObjectOfType<BossHPBar>(true).GetComponent<Slider>();
    }

    private void Update() {
        UpdateBossHealth();
    }
    private void UpdateBossHealth() {
        if (_bossEnemyList == null) { return; }
        if (_bossEnemyList.Count == 0) { return; }
        
        _currentBossHp = 0;
        
        for (int i = 0; i < _bossEnemyList.Count; i++) {
            if (_bossEnemyList[i] == null) { continue; }
            _currentBossHp += _bossEnemyList[i].stats.hp;
        }
        bossHealthBar.value = _currentBossHp;

        if (_currentBossHp <= 0) {
            bossHealthBar.gameObject.SetActive(false);
            _bossEnemyList.Clear();
        }
    }

    public void SpawnEnemy(EnemyData enemyToSPawn, bool isBoss) {
        Vector3 position = UtilityTools.GenerateRandomPositionSquarePattern(spawnArea);
        position += _player.transform.position;
        
        // Spawn main enemy object
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        
        Enemy newEnemyComponent = newEnemy.GetComponent<Enemy>();
        newEnemyComponent.SetStats(enemyToSPawn.stats);
        newEnemyComponent.SetTarget(_player);
        newEnemyComponent.UpdateStatsForProgression(stageProgress.Progress);

        if (isBoss) {
            SpawnBossEnemy(newEnemyComponent);
        }
        
        newEnemy.transform.parent = transform;

        // Spawn animated enemy sprite
        GameObject spriteObject = Instantiate(enemyToSPawn.animatedPrefab);
        spriteObject.transform.parent = newEnemy.transform;
        spriteObject.transform.localPosition = Vector3.zero;

    }
    private void SpawnBossEnemy(Enemy newBoss) {
        if (_bossEnemyList == null) { _bossEnemyList = new List<Enemy>(); }
        
        _bossEnemyList.Add(newBoss);
        _totalBossHp += newBoss.stats.hp;
        bossHealthBar.gameObject.SetActive(true);
        bossHealthBar.maxValue = _totalBossHp;
    }
}
