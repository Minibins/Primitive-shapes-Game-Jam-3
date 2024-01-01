using Unity.VisualScripting;

using UnityEngine;

public class PinkCubeEnemy : RedCubeEnemy
{
    
    [SerializeField] float _attackRange;
    Animator _anim;
    protected override void Start()
    {
        base.Start();
        _damage = 1;
        _maxSpeed = 2;
        _normalSpeed = 4;
        _anim = GetComponent<Animator>();
    }
    protected override void Move()
    {
        if(Vector2.Distance(transform.position,target.position) >= _attackRange)
        {
            base.Move();
        }
        else
        {
            _move.Run(Vector2.zero);
        }
    }
    protected override void Attack()
    {
        if(Vector2.Distance(transform.position,target.position) < _attackRange&& _normalSpeed != _maxSpeed)
        {
            _anim.Play("Attack");
        }
    }
    public void AttackAnimCallback()
    {
        if(Vector2.Distance(transform.position,target.position) < _attackRange)
        {
            target.GetComponent<PlayerHealth>().ApplyDamage(_damage);
        }
    }
    protected override void CloseAttack(Collision2D other)
    {
        _normalSpeed = _maxSpeed;
        _anim.Play("Stun");
    }
    
}
