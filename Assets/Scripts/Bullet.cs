using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected GameObject[] _bulletEffect;
    public float Damage;
    public bool IsPlayerBullet;
    private Gun _gun;

    public Gun Gun { set => _gun = value; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnSomethinEnter2D(other);
    }
    

    private void OnSomethinEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Enemy")&&IsPlayerBullet)
        {
            other.gameObject.GetComponent<EnemyHealth>().ApplyDamage(Damage);
            Instantiate(_bulletEffect[0], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Player") && !IsPlayerBullet)
        {
            other.gameObject.GetComponent<PlayerHealth>().ApplyDamage(Damage);
            Instantiate(_bulletEffect[0],transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Bullet"))
        {
            OtherBulletCollision();
        }
        else if(!other.gameObject.CompareTag("Coin"))
        {
            Instantiate(_bulletEffect[1], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OtherBulletCollision()
    {
        if(IsPlayerBullet)
        {
            Instantiate(_bulletEffect[2],transform.position,Quaternion.identity);
            _gun.Damage.Additions.Add(Damage * 2);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnSomethinEnter2D(other.collider);
    }
}