using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
public class Gun : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _spawnPoint;
    [SerializeField] private float _damage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private bool _isPlayer;
    [SerializeField] protected GameObject _sound;
    private Transform _player;
    private Camera _camera;
    public bool _canFire = true;
    protected float[] _offset = new float[2];
    protected float OffsetValue
    {
        get 
        {
            float Oval =0;
            foreach(float obj in _offset)
            {
                Oval+= obj;
            }
            return Oval; 
        }
    }
    private Queue<float> _gunSpinGoals;
    public bool IsSingleGun, IsBurstGun;
    [SerializeField] private float ReloadTime;

    public MultiplingVarieble<float> Damage;
    void OnEnable()
    {
        _player = Player.GetInstance();
        _camera = Camera.main;
        Damage = new MultiplingVarieble<float>(_damage);
        _gunSpinGoals = new Queue<float>();
        {
            UpdateGunGoals();
        }
    }

    private void UpdateGunGoals()
    { 
        _gunSpinGoals.Enqueue(((transform.rotation.eulerAngles.z + 60) + 180) % 360 - 180);
        _gunSpinGoals.Enqueue(((transform.rotation.eulerAngles.z + 180) + 180) % 360 - 180);
        _gunSpinGoals.Enqueue(((transform.rotation.eulerAngles.z + 300) + 180) % 360 - 180);
    }

    private void FixedUpdate()
    {

        WeaponTracking();
    }

    public virtual void WeaponTracking()
    {
        if (_player!=null)
        {
            if (_player.localScale.x < 0)
            {
                _offset[0] = 180;
            }
            else
            {
                _offset[0] = 0;
            }
            
        }
        Vector3 difference = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0f,0f,rotateZ + OffsetValue);

        if(System.Math.Abs(System.Math.Abs(System.Math.Abs(_gunSpinGoals.Peek()) - System.Math.Abs(transform.rotation.eulerAngles.z))) < 50)
        {
            _gunSpinGoals.Dequeue();
        }

        if(_gunSpinGoals.Count==0)
        {
            UpdateGunGoals();
            Damage.Additions.Add(3);
        }
    }
    public virtual void Fire()
    {
        if (_canFire)
        {
            StartCoroutine(FireWithDelay());
        }
    }

    private IEnumerator FireWithDelay()
    {
        _canFire = false;
        SingleFire();
        yield return new WaitForSeconds(ReloadTime); // Задержка между выстрелами
        _canFire = true;
    }

    public virtual void SingleFire()
    {
        GameObject _bullet = SpawnBullet();
        Bullet bullet = _bullet.GetComponent<Bullet>();
        bullet.Damage = Damage.Variable;
        bullet.Gun = this;
        Damage.Additions.Clear();

        if(_isPlayer)
        {
            _bullet.GetComponent<Bullet>().IsPlayerBullet = true;
            _bullet.layer = 7;
            if(_player.localScale.x < 0)
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
    }

    protected virtual GameObject SpawnBullet()
    {
        GameObject _bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
        Instantiate(_sound,_bullet.transform.position,Quaternion.identity,_bullet.transform);
        return _bullet;
    }
}