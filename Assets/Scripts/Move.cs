using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Run(Vector2 targetVelocity)
    {
        _rigidbody2D.velocity = targetVelocity;
    }
}