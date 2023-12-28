using UnityEngine;

public class RedCubeEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        _damage = 3;
        _maxSpeed = 5;
        _normalSpeed = 5;
    }

    protected override void Move()
    {
        Vector3 _direction = (target.position - transform.position).normalized;
        Vector3 _movement = _direction * _normalSpeed * Time.fixedDeltaTime;
        
        _rigidbody.MovePosition(transform.position + _movement);
    }

    protected override void CloseAttack(Collision2D other)
    {
        other.gameObject.GetComponent<PlayerHealth>().ApplyDamage(_damage);
        gameObject.GetComponent<EnemyHealth>().Die();
    }
    
}
