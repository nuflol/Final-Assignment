using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private new Rigidbody2D rigidbody2D;

    
    [HideInInspector] public Vector2 _movement;
    private Animate _animate;
    private SpriteRenderer _spriteRenderer;

    private Animator _animator;

    [HideInInspector] public float lastVertical;
    [HideInInspector] public float lastHorizontal;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start() {
        lastHorizontal = 1f;
        lastVertical = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("SpeedX", Mathf.Abs(_movement.x));
        _animator.SetFloat("SpeedY", Mathf.Abs(_movement.y));

        if (_movement.x != 0) {
            lastHorizontal = _movement.x;
        }
        if (_movement.y != 0) {
            lastVertical = _movement.y;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
        }
        
    }
    // Fixed Update is called at a fixed rate per frame
    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + _movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
