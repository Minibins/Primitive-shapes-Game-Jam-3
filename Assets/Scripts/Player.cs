using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rigidbody2D;
    private Move _move;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _move = GetComponent<Move>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (InputController._horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if (InputController._horizontalInput > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        
        Vector2 _targetVelocity = new Vector2(InputController._horizontalInput * _moveSpeed, InputController._verticalInput * _moveSpeed);
        _move.Run(_targetVelocity, _rigidbody2D);
    }
}