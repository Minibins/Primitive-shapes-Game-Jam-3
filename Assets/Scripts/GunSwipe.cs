using UnityEngine;

public class GunSwipe : MonoBehaviour, IShooting
{
    [SerializeField] private GameObject[] _guns;
    private int _indexGun;
    private IShooting _shootingImplementation;

    public void Fire()
    {
        _guns[_indexGun].GetComponent<Gun>().Fire();
    }

    public void SwipeUpGun()
    {
        _guns[_indexGun].SetActive(false);
        if (_indexGun == _guns.Length)
        {
            _indexGun = 0;
        }
        else
        {
            _indexGun++;
        }
        _guns[_indexGun].SetActive(true);
    }

    public void SwipeDownGun()
    {
        _guns[_indexGun].SetActive(false);
        if (_indexGun == 0)
        {
            _indexGun = _guns.Length;
        }
        else
        {
            _indexGun--;
        }
        _guns[_indexGun].SetActive(true);
    }
}