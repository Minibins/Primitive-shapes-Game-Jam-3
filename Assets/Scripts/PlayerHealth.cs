using UnityEngine;

using static UnityEngine.ParticleSystem;

public class PlayerHealth : Health
{
    [SerializeField] private GameObject LosePanel;
    private bool _isInvicible;
    private TrailRenderer _trail;
    private void Start()
    {
        _trail = GetComponent<TrailRenderer>();
    }
    public override void ApplyDamage(float _damage)
    {
        if (_isInvicible) { return; }
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
    public void AddInvisibility(float time)
    {
        _isInvicible = true;
        _trail.startColor = Color.yellow;
        _trail.endColor = Color.red;
        Invoke(nameof(RemoveInvisibility),time);
    }
    public void RemoveInvisibility()
    {
        _trail.startColor = Color.cyan;
        _trail.endColor = Color.blue;
        _isInvicible &= false;
    }
}