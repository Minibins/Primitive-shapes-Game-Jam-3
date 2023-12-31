using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject[] _bulletEffect;
    public float Damage;
    public bool IsPlayerBullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnSomethinEnter2D(other);
    }
    

    private void OnSomethinEnter2D(Collider2D other)
    {
        if(IsPlayerBullet)
        {
            if(other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyHealth>().ApplyDamage(Damage);
                Instantiate(_bulletEffect[0], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if(!other.gameObject.CompareTag("Coin"))
            {
                Instantiate(_bulletEffect[1], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerHealth>().ApplyDamage(Damage);
                Instantiate(_bulletEffect[0], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else  if(!other.gameObject.CompareTag("Coin"))
            {
                Instantiate(_bulletEffect[1], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnSomethinEnter2D(other.collider);
        if(!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}