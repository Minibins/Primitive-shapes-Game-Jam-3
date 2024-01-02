using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCircleGun : Turel
{
    protected override void Start()
    {
        base.Start();
        _offset[1] = 180;
    }
    public override void Fire() => ActionOnBurstFire();
}
