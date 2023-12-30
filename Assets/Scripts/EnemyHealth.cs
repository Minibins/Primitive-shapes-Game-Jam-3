using UnityEngine;

public class EnemyHealth: Health
    {
        [SerializeField] private GameObject coin;
    public override void ApplyDamage(int _damage)
    {
        _health -= _damage;

        if(_health <= 0)
        {
            Die();
        }
    }
    public override void RegenerateHealth(int _coutHealth)
    {
        base.RegenerateHealth(_coutHealth);
    }

    public override void Die()
    {
        Instantiate(coin, transform.position, Quaternion.identity);
       Destroy(gameObject);
    }
}
