using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private GameObject LosePanel;

    [SerializeField] private float _maxArmor;
    [SerializeField] private float _armor;
    [SerializeField] private Image[] _armorSprites;
    [SerializeField] private Image _emptyArmorSprite;
    [SerializeField] private Image _fullArmorSprite;
    [SerializeField] private InputController _inputController;

    private bool _isInvicible;
    private TrailRenderer _trail;

    private void Start()
    {
        _armor = _maxArmor;
        _trail = GetComponent<TrailRenderer>();
        StartCoroutine(ArmorRegeneration());
    }

    private IEnumerator ArmorRegeneration()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            if (_armor < _maxArmor)
            {
                _armor += 1;
                UpdateArmorSprites();
            }
        }
    }

    public override void ApplyDamage(float _damage)
    {
        if (_isInvicible) { return; }

        if (_armor <= 0)
        {
            _health -= _damage;

            if (_health <= 0)
            {
                Die();
            }
        }
        else
        {
            _armor -= _damage;
            UpdateArmorSprites();
        }
    }

    public override void RegenerateHealth(int _coutHealth)
    {
        base.RegenerateHealth(_coutHealth);
    }

    public override void Die()
    {
        _inputController.SetActiveJoysticks(false);
        LosePanel.SetActive(true);
    }

    private void UpdateArmorSprites()
    {
        if (_armorSprites != null)
        {
            for (int i = 0; i < _armorSprites.Length; i++)
            {
                if (i < _armor)
                {
                    _armorSprites[i].enabled = true;
                    _armorSprites[i].sprite = _fullArmorSprite.sprite;
                }
                else
                {
                    _armorSprites[i].enabled = false;
                }
            }
        }
    }

    public override void AddInvisibility(float time)
    {
        _isInvicible = true;
        _trail.startColor = Color.yellow;
        _trail.endColor = Color.red;
        Invoke(nameof(RemoveInvisibility), time);
    }

    public void RemoveInvisibility()
    {
        _trail.startColor = Color.cyan;
        _trail.endColor = Color.blue;
        _isInvicible = false;
    }
}
