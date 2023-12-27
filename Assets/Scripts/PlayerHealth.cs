using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameObject LosePanel;
    public override void ApplyDamage(int _damage)
    {
        base.ApplyDamage(_damage);
    }

    public override void RegenerateHealth(int _coutHealth)
    {
        base.RegenerateHealth(_coutHealth);
    }

    public override void Die()
    {
        LosePanel.SetActive(true);
    }
}