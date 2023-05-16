using UnityEngine;

public abstract class WeaponBase : MonoBehaviour {
    public WeaponData weaponData;
    public WeaponStats weaponStats;
    private float _timer;

    public void Update() {
        _timer -= Time.deltaTime;

        if (_timer < 0) {
            Attack();
            _timer = weaponStats.timeToAttack;
        }
    }

    public virtual void SetData(WeaponData wepData) {
        weaponData = wepData; 
        weaponStats = new WeaponStats(wepData.stats.damage, wepData.stats.timeToAttack, wepData.stats.numberOfAttacks);
    }
    public abstract void Attack();
    
    
    public virtual void PostDamage(int damage, Vector3 targetPos) {
        MessageSystem.Instance.PostMessage(damage.ToString(), targetPos);
    }
    public void Upgrade(UpgradeData upgradeData) {
        weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }
}
