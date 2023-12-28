using UnityEngine;

public class MoveEnemy : Enemy
{
    [SerializeField] private float _speed;

    protected override void Move()
    {
        transform.position += (transform.position - target.position).normalized * Time.deltaTime * _speed;
    }
}