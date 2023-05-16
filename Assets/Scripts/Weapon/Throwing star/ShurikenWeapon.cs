using UnityEngine;

public class ShurikenWeapon : WeaponBase {
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private float _spread = 0.5f;
    private PlayerMovement _playerMovement;
    
    
    private void Awake() {
        _playerMovement = GetComponentInParent<PlayerMovement>();
    }
    public override void Attack() {
        for (int i = 0; i < weaponStats.numberOfAttacks; i++) {
            GameObject thrownShuriken = Instantiate(knifePrefab);

            Vector3 newShurikenPosition = transform.position;
            if (weaponStats.numberOfAttacks > 1) {
                newShurikenPosition.y -= _spread * (weaponStats.numberOfAttacks-1) / 2;
                newShurikenPosition.y += i * _spread;
            }
            
            thrownShuriken.transform.position = newShurikenPosition; 
            
            ShurikenProjectile shurikenProjectile = thrownShuriken.GetComponent<ShurikenProjectile>();
            shurikenProjectile.SetDirection(_playerMovement.lastHorizontal, 0f);
            shurikenProjectile.damage = weaponStats.damage;
        }
    }
}

