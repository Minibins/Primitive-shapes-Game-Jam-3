using UnityEngine;

public class MoveEnemy : Enemy
{
    [SerializeField] private float Speed;
    protected override void Move()
    {
        transform.position += (transform.position - target.position).normalized*Time.deltaTime*Speed;
    }
}
