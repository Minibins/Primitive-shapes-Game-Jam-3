using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
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
                Destroy(gameObject);
            }
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().ApplyDamage(Damage);
            Destroy(gameObject);
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