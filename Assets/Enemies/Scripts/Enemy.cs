using UnityEngine;

public class Enemy : BetterBehavior
{
    protected Transform target;
    [SerializeField] protected float timeBetweenAttacking, timeBeforeAttacking;
    protected virtual void Start()
    {
        target = Player.instance;
        InvokeRepeating(nameof(Attack),timeBeforeAttacking,timeBetweenAttacking);
    }
    protected void FixedUpdate()
    {
        Move();
    }
    protected virtual void Move()
    {

    }
    protected virtual void Attack()
    {

    }
}