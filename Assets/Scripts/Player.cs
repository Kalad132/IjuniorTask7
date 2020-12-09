using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;

    private float _groundCheckDistance = 0.1f;
    private int _direction;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _sprite;
    private Animator _animator;
    private BoxCollider2D _collider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddForce(new Vector2(0, _jump));
        if (Input.GetKey(KeyCode.A))
            SetDirection(-1);
        else if (Input.GetKey(KeyCode.D))
            SetDirection(1);
        else
            SetDirection(0);
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector2(_direction * _speed * Time.deltaTime, 0));
    }

    private void SetDirection(int direction)
    {
        _direction = direction;
        if (direction == -1)
            _sprite.flipX = true;
        else if (direction == 1)
            _sprite.flipX = false;
        _animator.SetFloat("RunSpeed", Mathf.Abs(_direction));
    }

    private bool IsGrounded()
    {
        RaycastHit2D[] _hit = Physics2D.BoxCastAll(_collider.bounds.min, new Vector2(0.1f, 0.1f), 0f, Vector2.down, _groundCheckDistance);
        _animator.SetBool("Grounded", _hit.Length > 1);
        return _hit.Length>1;
    }


}



