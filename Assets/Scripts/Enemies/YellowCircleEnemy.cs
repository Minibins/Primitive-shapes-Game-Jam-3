using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCircleEnemy : RedCubeEnemy
{
    YellowCircleGun _gun;
    protected override void Start()
    {
        _gun = GetComponentInChildren<YellowCircleGun>();
        base.Start();
        _normalSpeed = 4;
    }
    protected override void Attack()
    {
        _gun.Fire();
    }
    protected override void CloseAttack(Collision2D other)
    {
        
    }
}
