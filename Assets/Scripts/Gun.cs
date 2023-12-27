using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _reloadTime;
    [SerializeField] private int _damage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private bool _isPlayer;
    private Transform _player;
    private float _lastShotTime;
    private Camera _camera;
    private float _offset;

    private void Start()
    {
        _player = GameObject.Find("Player").transform;
        _lastShotTime = -_reloadTime;
        _camera = Camera.main;
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
    }

    public virtual void Fire()
    {
        if (Time.time - _lastShotTime > _reloadTime)
        {
            _lastShotTime = Time.time;
            
            GameObject _bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
            _bullet.GetComponent<Bullet>().Damage = _damage;

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
        }
    }
    
    
}