using UnityEngine;

public class ShurikenProjectile : MonoBehaviour {
    private Vector3 _direction;

    [SerializeField] private float speed;
    public int damage;
    private float _ttl = 6f;

    public void SetDirection(float dirX,float dirY) {
        _direction = new Vector3(dirX,dirY);

        if (dirX < 0) {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }
    
    private bool _hitDetected;
    
    void Update() { 
        transform.position += _direction * (speed * Time.deltaTime);

        // Skipping checks some frames to save performance
        if (Time.frameCount % 6 == 0) {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f);
            foreach (Collider2D c in hit) {
                IDamageable enemy = c.GetComponent<IDamageable>();
                if (enemy != null) {
                    PostDamage(damage, transform.position);
                    enemy.TakeDamage(damage);
                    _hitDetected = true;
                    break;
                }
            }
            if (_hitDetected == true) {
                Destroy(gameObject);
            }   
        }
        _ttl -= Time.deltaTime;
        if (_ttl < 0f) {
            Destroy(gameObject);
        }
    }

    public void PostDamage(int damage, Vector3 worldPosition) {
        MessageSystem.Instance.PostMessage(this.damage.ToString(), worldPosition);
    }
}
