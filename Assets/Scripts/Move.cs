using UnityEngine;

public class Move : MonoBehaviour
{
    public void Run(Vector2 targetVelocity, Rigidbody2D rigidbody2D)
    {
        rigidbody2D.velocity = targetVelocity;
    }
}