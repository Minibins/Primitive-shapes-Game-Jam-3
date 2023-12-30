using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _maxHealth;
    
    [SerializeField] private Image[] _heartSprites; // Массив изображений сердец
    [SerializeField] private Image _emptyHeartSprite; // Спрайт для пустого сердца
    [SerializeField] private Image _fullHeartSprite; // Спрайт для заполненного сердца

    private void Start()
    {
        _health = _maxHealth;
        UpdateHealthSprites();
    }

    public virtual void ApplyDamage(int damage)
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