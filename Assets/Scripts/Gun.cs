using UnityEngine;
using System.Collections.Generic;
using System;
public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _damage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private bool _isPlayer;
    [SerializeField] private GameObject _sound;
    private Transform _player;
    private Camera _camera;
    private float _offset;
    private Queue<float> _gunSpinGoals;

    public MultiplingVarieble<int> Damage;
    private void Start()
    {
        _player = GameObject.Find("Player").transform;
        _camera = Camera.main;
        Damage = new MultiplingVarieble<int>(_damage);
        _gunSpinGoals = new Queue<float>();
        {
            UpdateGunGoals();
            print(_gunSpinGoals.Peek());
        }
    }

    private void UpdateGunGoals()
    {
        _gunSpinGoals.Clear();
        _gunSpinGoals.Enqueue(((transform.rotation.eulerAngles.z + 60) + 180) % 360 - 180);
        _gunSpinGoals.Enqueue(((transform.rotation.eulerAngles.z + 180) + 180) % 360 - 180);
        _gunSpinGoals.Enqueue(((transform.rotation.eulerAngles.z + 300) + 180) % 360 - 180);
    }

    private void Update()
    {
        if (_player.localScale.x < 0)
        {
            _offset = 180;
        }
        else
        {
            _offset = 0;
        }

        WeaponTracking();
    }

    public virtual void WeaponTracking()
    {
        Vector3 difference = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);

        if(_gunSpinGoals.Peek()< transform.rotation.eulerAngles.z)
        {
            _gunSpinGoals.Dequeue();
        }

        if(_gunSpinGoals.Count==0)
        {
            UpdateGunGoals();
            Damage.Additions.Add(3);
            print("Ваш пистолет заряжен");
        }
    }

    public virtual void Fire()
    {
        
        GameObject _bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
        Instantiate(_sound, _bullet.transform.position, Quaternion.identity, _camera.transform);
        _bullet.GetComponent<Bullet>().Damage = Convert.ToInt32( Damage.Variable);

        if (_isPlayer)
        {
            _bullet.GetComponent<Bullet>().IsPlayerBullet = true;
            _bullet.layer = 7;
            if (_player.localScale.x < 0)
            {
                _bullet.GetComponent<Rigidbody2D>().velocity = _bullet.transform.right * -_bulletSpeed;
            }
            else
            {
                _bullet.GetComponent<Rigidbody2D>().velocity = _bullet.transform.right * _bulletSpeed;
            }
        }
        else
        {
            _bullet.GetComponent<Bullet>().IsPlayerBullet = false;
            _bullet.GetComponent<Rigidbody2D>().velocity = _bullet.transform.right * -_bulletSpeed;
        }
        UpdateGunGoals();
        Damage.Additions = new List<float>();
    }
    
    
}