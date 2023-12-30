using UnityEngine;

using static UnityEngine.GraphicsBuffer;

public class Turel : Gun, IShooting
{
    private IShooting _shootingImplementation;
    Transform _target;
    private void Awake()
    {
        _target = Player.instance;
    }
    public override void Fire()
    {
        base.Fire();
    }
    
    public override void WeaponTracking()
    {        
        Vector3 difference = _target.position - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        
    }
    public void SwipeUpGun()
    {
        _shootingImplementation.SwipeUpGun();
    }

    public void SwipeDownGun()
    {
        _shootingImplementation.SwipeDownGun();
    }
}
