using UnityEngine;

public class GunSwipe : MonoBehaviour, IShooting
{
   // [SerializeField] private GameObject[] _guns;
    private int _indexGun;
    private IShooting _shootingImplementation;

    public GunItem[] GunItems;

    public void Fire()
    {
      //  if (_guns[_indexGun].GetComponent<Gun>().CanSwipe)
        if (GunItems[_indexGun].CanSwap)
        {
           // if (!_guns[_indexGun].GetComponent<Gun>().IsSingleGun)
            if (!GunItems[_indexGun].GunPrefab.GetComponent<Gun>().IsSingleGun)
             //   _guns[_indexGun].GetComponent<Gun>().Fire();
                GunItems[_indexGun].GunPrefab.GetComponent<Gun>().Fire();
        }
    } 

    public void SingleFire()
    {
        if (GunItems[_indexGun].CanSwap)
        {
            GunItems[_indexGun].GunPrefab.GetComponent<Gun>().Fire();
        }
    }

    public void SwipeUpGun()
    {
        int originalIndex = _indexGun;
        do
        {
            _indexGun = (_indexGun + 1) % GunItems.Length;
        } while (!GunItems[_indexGun].CanSwap && _indexGun != originalIndex);

        GunItems[originalIndex].GunPrefab.SetActive(false);
        GunItems[_indexGun].GunPrefab.SetActive(true);
    }

    public void SwipeDownGun()
    {
        int originalIndex = _indexGun;
        do
        {
            _indexGun = (_indexGun - 1 + GunItems.Length) % GunItems.Length;
        } while (!GunItems[_indexGun].CanSwap && _indexGun != originalIndex);

        GunItems[originalIndex].GunPrefab.SetActive(false);
        GunItems[_indexGun].GunPrefab.SetActive(true);
    }

}


[System.Serializable]
public class GunItem
{
    public GameObject GunPrefab;
    public bool CanSwap;
}
