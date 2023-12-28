using System;
using UnityEngine;

public abstract class Enemy : BetterBehavior
{
    protected Rigidbody2D _rigidbody;
    protected int _damage;
    protected float _maxSpeed = 5f;
    protected float _normalSpeed = 5f;
    protected Transform target;

    [SerializeField] protected float timeBetweenAttacking, timeBeforeAttacking;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        // target = Player.instance;
        target = GameObject.Find("Player").transform;
        InvokeRepeating(nameof(Attack), timeBeforeAttacking, timeBetweenAttacking);
    }

    protected void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CloseAttack(other);
        }
    }

    
    protected virtual void Move()
    {
        
    }

    protected virtual void CloseAttack(Collision2D other)
    {
        
    }

    protected virtual void Attack()
    {
     
    }
}