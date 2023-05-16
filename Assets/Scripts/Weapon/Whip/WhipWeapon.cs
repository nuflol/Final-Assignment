using System.Collections;
using UnityEngine;

public class WhipWeapon : WeaponBase {
    [SerializeField] private Vector2 attackSize = new Vector2(4f, 2f);
    [SerializeField] private GameObject leftWhipObj;
    [SerializeField] private GameObject rightWhipObj;
    private PlayerMovement _playerMovement;
    
    private void Awake() {
        _playerMovement = GetComponentInParent<PlayerMovement>();
    }

    public override void Attack() {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess() {
        for (int i = 0; i < weaponStats.numberOfAttacks; i++) {
            if (_playerMovement.lastHorizontal > 0) {
                rightWhipObj.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObj.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
            else {
                leftWhipObj.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObj.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void ApplyDamage(Collider2D[] colliders) {
        for (int i = 0; i < colliders.Length; i++) {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null) {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);  
            }
        }
    }
}
