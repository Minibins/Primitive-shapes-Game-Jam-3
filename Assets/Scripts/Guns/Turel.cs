using UnityEngine;
public class Turel : Gun, IShooting
{
    private IShooting _shootingImplementation;
    Transform _target;

    protected virtual void Start()
    {
        _target = Player.GetInstance();
    }

    public new void SingleFire()
    {
        throw new System.NotImplementedException();
    }

    public override void WeaponTracking()
    {
        try
        {
            Vector3 difference = _target.position - transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + OffsetValue);
        }
        catch
        {
            _target = Player.GetInstance();
        }
    }
    public override void Fire() => ActionOnBurstFire();
    

    public void SwipeUpGun()
    {
        _shootingImplementation.SwipeUpGun();
    }

    public void SwipeDownGun()
    {
        _shootingImplementation.SwipeDownGun();
    }
}