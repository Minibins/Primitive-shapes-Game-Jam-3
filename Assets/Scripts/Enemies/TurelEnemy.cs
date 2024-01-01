using UnityEngine;

public class TurelEnemy : Enemy
{
   private IShooting _gun;
    protected override void Start()
    {
        base.Start();
        _gun = GetComponentInChildren<Turel>();
    }
    protected override void Attack()
    {
        _gun.Fire();
    }
}
