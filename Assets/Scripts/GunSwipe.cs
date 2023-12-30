using UnityEngine;

public class GunSwipe : MonoBehaviour, IShooting
{
    [SerializeField] private GameObject[] _guns;
    private int _indexGun;
    private IShooting _shootingImplementation;

    public void Fire()
    {
        if(!_guns[_indexGun].GetComponent<Gun>().IsSingleGun)
            _guns[_indexGun].GetComponent<Gun>().Fire();
    }

    public void SingleFire()
    {
        _guns[_indexGun].GetComponent<Gun>().Fire();
    }

    public void SwipeUpGun()
    {
        _guns[_indexGun].SetActive(false);
        _indexGun = (_indexGun + 1) % _guns.Length; // Используем операцию остатка от деления, чтобы обеспечить зацикливание
        _guns[_indexGun].SetActive(true);
    }

    public void SwipeDownGun()
    {
        _guns[_indexGun].SetActive(false);
        _indexGun = (_indexGun - 1 + _guns.Length) % _guns.Length; // Используем операцию остатка от деления, чтобы обеспечить зацикливание
        _guns[_indexGun].SetActive(true);
    }
}