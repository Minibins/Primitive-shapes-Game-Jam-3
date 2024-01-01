using  UnityEngine.UI;
using UnityEngine;

public class GunSwipe : MonoBehaviour, IShooting
{
   // [SerializeField] private GameObject[] _guns;
    private int _indexGun;
    private IShooting _shootingImplementation;
    [SerializeField] private Image _swipeGunButtonImage;
    public GunItem[] GunItems;

    public void Fire()
    {
        if (GunItems[_indexGun].CanSwap)
        {
            if (GunItems[_indexGun].Gun.IsBurstGun)
                GunItems[_indexGun].Gun.Fire();
        }
    } 

    public void SingleFire()
    {
        if (GunItems[_indexGun].CanSwap&& GunItems[_indexGun].Gun.IsSingleGun)
        {
            GunItems[_indexGun].Gun.SingleFire();
        }
    }

    public void SwipeUpGun()
    {
        SwipeGun(true);
    }

    public void SwipeDownGun()
    {
        SwipeGun(false);
    }
    public void SwipeGun(bool direction)
    {
        var originalIndex = _indexGun;
        do
        {
            _indexGun = (_indexGun + MathAVM.MathA.OneOrNegativeOne(direction) + GunItems.Length) % GunItems.Length;
        } while(!GunItems[_indexGun].CanSwap && _indexGun != originalIndex);

        GunItems[originalIndex].GunPrefab.SetActive(false);
        _swipeGunButtonImage.sprite = GunItems[_indexGun].Icon;
        GunItems[_indexGun].GunPrefab.SetActive(true);
        GunItems[_indexGun].Gun._canFire = true;
    }
}


[System.Serializable]
public class GunItem
{
    public GameObject GunPrefab;
    public Gun Gun;
    public bool CanSwap;
    public Sprite Icon;
}
