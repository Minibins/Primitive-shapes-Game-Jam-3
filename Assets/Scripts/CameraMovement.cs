using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float smoothTime = 0.3f;
    private Transform _player;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public static void Shake()
    {
        print("testCamera");
    }
}