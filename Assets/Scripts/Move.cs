using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _moveSpeed = 1f;
    private MultiplingVarieble<float> MoveSpeed;

    private Health _health;

    [SerializeField] private float timeOfWallSpeeding = 0.3f;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _collision = GetComponent<Collider2D>();
        MoveSpeed = new MultiplingVarieble<float>(_moveSpeed);
    }
    public void Run(Vector2 targetVelocity)
    {
        _rigidbody2D.velocity = targetVelocity* MoveSpeed.Variable;
    }
    bool isCollisionExitNow;
    Collider2D _collision;
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(_collision.OverlapCollider(new ContactFilter2D(),new Collider2D[1]) > 0) return;
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