using UnityEngine;

public class Turel : Gun, IShooting
{
    private IShooting _shootingImplementation;
    
    public void SingleFire()
    {
        throw new System.NotImplementedException();
    }

    public override void WeaponTracking()
    {
        Transform _player = GameObject.Find("Player").transform;
        
        
        Vector3 difference = _player.position - transform.position;
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
