using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _maxHealth;
    
    [SerializeField] private Image[] _heartSprites; 
    [SerializeField] private Image _emptyHeartSprite; 
    [SerializeField] private Image _fullHeartSprite; 

    public virtual void AddInvisibility(float time)
    {

    }
    private void Start()
    {
        _health = _maxHealth;
        UpdateHealthSprites();
    }

    public virtual void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }

        UpdateHealthSprites();
    }

    public virtual void RegenerateHealth(int healthAmount)
    {
        if (_health < _maxHealth)
        {
            _health += healthAmount;
            UpdateHealthSprites();
        }
    }

    private void UpdateHealthSprites()
    {
        if (_heartSprites != null)
        {
            // Обновление видимости изображений в зависимости от текущего здоровья
            for (int i = 0; i < _heartSprites.Length; i++)
            {
                if (i < _health)
                {
                    // Отображение заполненного сердца
                    _heartSprites[i].enabled = true;
                    _heartSprites[i].sprite = _fullHeartSprite.sprite; // Установка спрайта
                }
                else
                {
                    // Отключение изображения для пустого сердца
                    _heartSprites[i].enabled = false;
                }
            }
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}