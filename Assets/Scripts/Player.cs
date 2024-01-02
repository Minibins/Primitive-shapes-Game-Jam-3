using System;
using MathAVM;

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using static UnityEngine.GraphicsBuffer;

public class Player : BetterBehavior
{
    [SerializeField] private Text _coinText;
    public int coins;
    private Move _move;
    public static Transform instance;
    public static Transform GetInstance()
    {
        if (instance != null)
        {
            return instance;
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player == null) throw new Exception("Игрока по какой-то причине не нашли");
            instance = player.transform;
            return player.transform;
        }
    }

    private void Start()
    {
        _coinText.text = "Money: <color=yellow>" + coins.ToString() + "</color>";
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
            _move.Run(_targetVelocity);
        };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            _coinText.text = "Money: <color=yellow>" + coins.ToString() + "</color>";
            Destroy(other.gameObject);
        }
    }
}