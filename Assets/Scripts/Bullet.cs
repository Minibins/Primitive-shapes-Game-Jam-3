using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int _damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}