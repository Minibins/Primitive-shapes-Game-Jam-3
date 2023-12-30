using Unity.VisualScripting;

using UnityEngine;

public class RedCubeEnemy : Enemy
{
    [SerializeField] LayerMask _wallMask, _playerMask;
    private Vector2 lastPos;
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
        Vector3 _reversedMovement = _movement;
        while(CantWalk(_movement)&&CantWalk(_reversedMovement))
        {
            _movement = MathAVM.MathA.RotatedVector(_movement,25);
            _reversedMovement = MathAVM.MathA.RotatedVector(_reversedMovement,-25);
            if(_movement == _direction * _normalSpeed * Time.fixedDeltaTime || !CantWalk(_movement)) break;
            if(!CantWalk(_reversedMovement)) _movement = _reversedMovement;
        }
        Debug.DrawRay(transform.position,_movement * 22);
        _rigidbody.MovePosition(transform.position + _movement);
        lastPos = transform.position;
    }

    private bool CantWalk(Vector3 _movement)
    {
        return (Physics2D.Raycast(transform.position + new Vector3(0.5f,0.5f,0),_movement,_normalSpeed,_wallMask) ||
                    Physics2D.Raycast(transform.position + new Vector3(0.5f,-0.5f,0),_movement,_normalSpeed,_wallMask) ||
                    Physics2D.Raycast(transform.position + new Vector3(-0.5f,-0.5f,0),_movement,_normalSpeed,_wallMask) ||
                    Physics2D.Raycast(transform.position + new Vector3(-0.5f,0.5f,0),_movement,_normalSpeed,_wallMask))
                    && !Physics2D.Raycast(transform.position,_movement,_normalSpeed,_playerMask);
    }

    protected override void CloseAttack(Collision2D other)
    {
        other.gameObject.GetComponent<PlayerHealth>().ApplyDamage(_damage);
        gameObject.GetComponent<EnemyHealth>().Die();
    }
    
}
