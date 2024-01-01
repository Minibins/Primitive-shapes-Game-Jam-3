using System;
using UnityEngine;

public class BossAttack : Gun, IShooting
{
    
    
    [SerializeField] private float _spawnRadius;
    [SerializeField] private GameObject[] _bulletPrefabs;

    private BossEnemy _bossEnemy;
    private void Start()
    {
        _bossEnemy = GetComponent<BossEnemy>();
    }

    public override void Fire()
    {
        switch (_bossEnemy.AttackTypes)
        {
            case BossEnemy.AttackType.AroundAttack:
                BulletAroundAttack();
                break;
            
            case BossEnemy.AttackType.SingleAttack:
                BulletSingleAttack();
                break;
            
            case BossEnemy.AttackType.AroundBossAttack:
                BulletAroundBossAttack();
                break;
            
            case BossEnemy.AttackType.AroundFolowAttack:
                BulletAroundFolowAttack();
                break;
        }
    }

    private void BulletAroundBossAttack()
    {
        int numberOfBullets = 8;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float randomAngle = i * (360f / numberOfBullets);

            float radianAngle = Mathf.Deg2Rad * randomAngle;

            float x = Mathf.Cos(radianAngle) * _spawnRadius;
            float y = Mathf.Sin(radianAngle) * _spawnRadius;

            GameObject _bullet =
                Instantiate(_bulletPrefabs[3], transform.position + new Vector3(x, y, 0f), Quaternion.identity);

            _bullet.GetComponent<AroundBullet>().centerPoint = transform;
            
            _bullet.GetComponent<AroundBullet>().RotationSpeed = 50f;
            _bullet.GetComponent<AroundBullet>().IsAround = true;
            
            
            Instantiate(_sound, _bullet.transform.position, Quaternion.identity, _bullet.transform);

            _bullet.GetComponent<Bullet>().IsPlayerBullet = false;

            _bullet.GetComponent<Bullet>().Damage = 1;
            Damage.Additions.Clear();
        }
    }
    private void BulletSingleAttack()
    {
        // Стреляем одной пулей в сторону игрока
        GameObject singleBullet = Instantiate(_bulletPrefabs[0], transform.position, Quaternion.identity);
        
        
        Instantiate(_sound, singleBullet.transform.position, Quaternion.identity, singleBullet.transform);

        singleBullet.GetComponent<Bullet>().IsPlayerBullet = false;

        Vector3 bulletDirectionToPlayer = (_player.position - transform.position).normalized;
        singleBullet.GetComponent<Rigidbody2D>().velocity = bulletDirectionToPlayer * _bulletSpeed;

        singleBullet.GetComponent<Bullet>().Damage = 3;
        Damage.Additions.Clear();
    }
    private void BulletAroundAttack()
    {
        int numberOfBullets = 8;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float randomAngle = i * (360f / numberOfBullets);

            float radianAngle = Mathf.Deg2Rad * randomAngle;

            float x = Mathf.Cos(radianAngle) * _spawnRadius;
            float y = Mathf.Sin(radianAngle) * _spawnRadius;

            GameObject _bullet =
                Instantiate(_bulletPrefabs[1], transform.position + new Vector3(x, y, 0f), Quaternion.identity);
            Instantiate(_sound, _bullet.transform.position, Quaternion.identity, _bullet.transform);

            _bullet.GetComponent<Bullet>().IsPlayerBullet = false;

            Vector3 bulletDirection = new Vector3(x, y, 0f);
            _bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * _bulletSpeed;

            _bullet.GetComponent<Bullet>().Damage = 1;
            Damage.Additions.Clear();
        }
    }
    private void BulletAroundFolowAttack()
    {
        int numberOfBullets = 3;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float randomAngle = i * (360f / numberOfBullets);

            float radianAngle = Mathf.Deg2Rad * randomAngle;

            float x = Mathf.Cos(radianAngle) * _spawnRadius*3;
            float y = Mathf.Sin(radianAngle) * _spawnRadius*3;

            GameObject _bullet =
                Instantiate(_bulletPrefabs[2], transform.position + new Vector3(x, y, 0f), Quaternion.identity);

            _bullet.GetComponent<FolowBullet>().targetTransform = _player;
            
            _bullet.GetComponent<FolowBullet>().FollowSpeed = 6f;
            _bullet.GetComponent<FolowBullet>().IsFolow = true;
            
            
            Instantiate(_sound, _bullet.transform.position, Quaternion.identity, _bullet.transform);

            _bullet.GetComponent<Bullet>().IsPlayerBullet = false;

          // Vector3 bulletDirection = new Vector3(x, y, 0f);
          //  _bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * _bulletSpeed;

            _bullet.GetComponent<Bullet>().Damage = 1;
            Damage.Additions.Clear();
        }
    }


    public void SingleFire()
    {
        throw new System.NotImplementedException();
    }
    public void SwipeUpGun()
    {
        throw new System.NotImplementedException();
    }
    public void SwipeDownGun()
    {
        throw new System.NotImplementedException();
    }
}