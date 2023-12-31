using MathAVM;

using Unity.VisualScripting;

using UnityEngine;

public class Kalash : Gun
{
    [SerializeField] SinusWave spread;
    public override void WeaponTracking()
    {
        _offset[1] = spread.Value;
        base.WeaponTracking();
    }
    protected override GameObject SpawnBullet()
    {
        spread.CurrentPos++;
        return base.SpawnBullet();
    }
}
