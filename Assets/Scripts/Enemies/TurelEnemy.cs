using UnityEngine;

public class TurelEnemy : Enemy
{
   private IShooting _gun;
    protected override void Start()
    {
        _gun = GetComponentInChildren<Turel>();
        base.Start();
    }
    protected override void Attack()
    {
        _gun.Fire();
    }
}
