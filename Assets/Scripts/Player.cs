using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float timeOfWallSpeeding = 0.3f;
    [SerializeField] private float _moveSpeed;
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
        instance = transform;
        _move = GetComponent<Move>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 _targetVelocity = new Vector2(InputController._horizontalInput * MoveSpeed,
            InputController._verticalInput * MoveSpeed);
        instance.localScale.Scale(_targetVelocity);
        _move.Run(_targetVelocity);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _multiplerSpeed.Add(1.5f);
        StartCoroutine(ResetSpeed(1.5f));
    }

    private IEnumerator ResetSpeed(float value)
    {
        yield return new WaitForSeconds(timeOfWallSpeeding);
        _multiplerSpeed.Remove(value);
    }
}