using MathAVM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerHealth _health;
    [SerializeField] private float timeOfWallSpeeding = 0.3f;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Text _coinText;
    [SerializeField] private int coins;
    private List<float> _multiplerSpeed = new List<float>();
    private Move _move;
    public static Transform instance;

    public float MoveSpeed
    {
        get
        {
            float Multiplers = 1f;
            foreach (var value in _multiplerSpeed)
            {
                Multiplers *= value;
            }

            return _moveSpeed * Multiplers;
        }
        set => _moveSpeed = value;
    }

    private void Start()
    {
        _health = GetComponent<PlayerHealth>();
        instance = transform;
        _move = GetComponent<Move>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 _targetVelocity = new Vector2(InputController._horizontalInput, InputController._verticalInput);
        if(_targetVelocity.magnitude > 0.1f)
        {
            instance.localScale = new Vector3(MathA.OneOrNegativeOne(_targetVelocity.x),MathA.OneOrNegativeOne(_targetVelocity.y),1);
            _move.Run(_targetVelocity * MoveSpeed);
        };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            _coinText.text = "Money:" + coins.ToString();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _multiplerSpeed.Add(1.5f);
        _health.AddInvisibility(timeOfWallSpeeding);
        Invoke(nameof(ResetSpeed),timeOfWallSpeeding);

    }
    private void ResetSpeed()
    {
        _multiplerSpeed.Remove(1.5f);
    }
}