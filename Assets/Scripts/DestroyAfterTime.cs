using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float _delay;

    private void Start()
    {
        Destroy(gameObject, _delay);
    }
}