using MathAVM;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static UnityEngine.GraphicsBuffer;

public class Player : BetterBehavior
{
    Collider2D _collision;
    private PlayerHealth _health;
    [SerializeField] private float timeOfWallSpeeding = 0.3f;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Text _coinText;
    [SerializeField] private int coins;
    private MultiplingVarieble<float> MoveSpeed;
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
        _collision= GetComponent<Collider2D>();
        _health = GetComponent<PlayerHealth>();
        instance = transform;
        _move = GetComponent<Move>();
        MoveSpeed = new MultiplingVarieble<float>(_moveSpeed);
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
            _move.Run(_targetVelocity * MoveSpeed.Variable);
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
    bool isCollisionExitNow;
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(_collision.OverlapCollider(new ContactFilter2D(),new Collider2D[1])>0) return;
        if(isCollisionExitNow) return;
        MoveSpeed.Multiplers.Add(1.5f);
        _health.AddInvisibility(timeOfWallSpeeding);
        Invoke(nameof(ResetSpeed),timeOfWallSpeeding);
        StartCoroutine(ResetCollisionExit());
    }
    private IEnumerator ResetCollisionExit()
    {
        isCollisionExitNow = true;
        yield return new WaitForEndOfFrame();
        isCollisionExitNow = false;
    }
    private void ResetSpeed()
    {
        MoveSpeed.Multiplers.Remove(1.5f);
    }
}