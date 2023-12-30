using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private GameObject _priceText;
    [SerializeField] private int _price;
    [SerializeField] private Canvas _canvas;

    private Player _player;
    private bool _isPlayerInside = false;
    
    private void Start()
    {
        _priceText.GetComponent<Text>().text = "Price:" + _price;
       _canvas.worldCamera = Camera.main;
       _player = FindObjectOfType<Player>();
    }
    
    private void Update()
    {
        if (_isPlayerInside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_player.coins >= _price)
                {
                    _player.coins -= _price;
                   
                    Buy();
                }
            }
            _priceText.SetActive(true);
        }
        else
        {
            _priceText.SetActive(false);
        }
    }

    public virtual void Buy()
    {
        print("Покупаю");
        Destroy(gameObject);
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerInside = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerInside = false;
        }
    }
}
