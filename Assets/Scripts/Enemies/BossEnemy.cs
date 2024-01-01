using System.Collections;
using UnityEngine;

public class BossEnemy : Enemy
{
    public bool CanMove;
    public BoosRoom _bossRoom;

    private IShooting _gun;


    public AttackType AttackTypes;
    public enum AttackType
    {
        AroundAttack,
        SingleAttack,
        AroundFolowAttack,
        AroundBossAttack,
    }


    protected override void Start()
    {
        base.Start();
        _gun = GetComponentInChildren<BossAttack>();
    }

    protected override void Move()
    {
        if (CanMove)
        {
        }
    }

    protected override void Attack()
    {
        if (CanMove)
        {
            _gun.Fire();
        }
    }
}