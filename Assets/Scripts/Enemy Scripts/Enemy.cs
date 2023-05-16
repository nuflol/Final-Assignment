using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class EnemyStats {
    public int hp = 5;
    public int damage = 1;
    public int xpReward = 100;
    public float moveSpeed = 1f;

    public EnemyStats(EnemyStats stats) {
        this.hp = stats.hp;
        this.damage = stats.damage;
        this.xpReward = stats.xpReward;
        this.moveSpeed = stats.moveSpeed;
    }

    internal void ApplyProgress(float progress) {
        this.hp = (int)(hp * progress);
        this.damage = (int)(damage * progress);
    }
}

public class Enemy : MonoBehaviour, IDamageable {
    private Transform _targetDestination;
    private Rigidbody2D _rigidbody2D;
    private GameObject _targetGameObject;
    private Character _targetCharacter;

    public EnemyStats stats;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target) {
        _targetGameObject = target;
        _targetDestination = target.transform;
    }

    private void FixedUpdate() {
        Vector3 direction = (_targetDestination.position - transform.position).normalized;
        _rigidbody2D.velocity = direction * stats.moveSpeed;
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject == _targetGameObject) {
            Attack();
        }
    }
    private void Attack() {
        if (_targetCharacter == null) {
            _targetCharacter = _targetGameObject.GetComponent<Character>();
        }
        _targetCharacter.TakeDamage(stats.damage);
    }

    public void TakeDamage(int damage) {
        stats.hp -= damage;

        if (stats.hp < 1) {
            _targetGameObject.GetComponent<Level>().AddXP(stats.xpReward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }
    internal void SetStats(EnemyStats stats) {
        this.stats = new EnemyStats(stats);
    }
    internal void UpdateStatsForProgression(float progress) {
        stats.ApplyProgress(progress);
    }
}
