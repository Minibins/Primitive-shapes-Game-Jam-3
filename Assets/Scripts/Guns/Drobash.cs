using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drobash : Gun
{
    [SerializeField] int _maxBulletCount,_bulletCount;
    [SerializeField] float _DistanceBetweenBullets;
    [SerializeField] GameObject _reloadSound;
    bool canReload;
    public override void SingleFire()
    {
        if(_bulletCount <= 0)
        {
            return;
        }
        _offset[1] = -_DistanceBetweenBullets * _maxBulletCount / 2f;
        for(int i=0;  i < _bulletCount; i++)
        {
            _offset[1] += _DistanceBetweenBullets;
            WeaponTracking();
            base.SingleFire();
        }
        _offset[1] = 0;
        _bulletCount--;
        canReload = false;
    }
    protected override void ActionOnBurstFire()
    {
        if( _bulletCount < _maxBulletCount&&canReload)
        {
            _bulletCount++;
            Instantiate(_reloadSound,transform);
        }
        else
        {
            canReload = true;
        }
    }
}
