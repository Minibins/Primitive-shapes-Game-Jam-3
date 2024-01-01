using System.Collections;
using UnityEngine;

public class BossEnemy : RedCubeEnemy
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
            base.Move();
        }
    }

    protected override void Attack()
    {
        if (CanMove)
        {
            _gun.Fire();
            if(Random.Range(1,3)==1)
            {
                AttackTypes = (AttackType)Random.Range(0,4);
            }
        }
    }
    protected override void CloseAttack(Collision2D other)
    {
        
    }
}