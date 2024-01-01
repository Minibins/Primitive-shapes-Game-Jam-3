using UnityEngine;

public abstract class Enemy : BetterBehavior
{
    protected Rigidbody2D _rigidbody;
    protected int _damage;
    [SerializeField] protected float _maxSpeed = 5f;
    [SerializeField] protected float _normalSpeed = 5f;
    protected Transform target;

    [SerializeField] protected float timeBetweenAttacking, timeBeforeAttacking;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        target = Player.GetInstance();
        InvokeRepeating(nameof(invokeAttack), timeBeforeAttacking, timeBetweenAttacking);
    }

    protected void FixedUpdate()
    {
        if (Vector2.Distance(target.position, transform.position) < 40) Move();
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

    private void invokeAttack()
    {
        if (Vector2.Distance(target.position, transform.position) < 40) Attack();
    }

    protected virtual void Attack()
    {
    }
}