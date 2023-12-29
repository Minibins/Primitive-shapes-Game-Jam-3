using MathAVM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Collider2D _collision;
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
        _collision= GetComponent<Collider2D>();
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
    bool isCollisionExitNow;
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(_collision.OverlapCollider(new ContactFilter2D(),new Collider2D[1])>0) return;
        if(isCollisionExitNow) return;
        _multiplerSpeed.Add(1.5f);
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
        _multiplerSpeed.Remove(1.5f);
    }
}