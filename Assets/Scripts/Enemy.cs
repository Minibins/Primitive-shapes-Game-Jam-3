using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private IShooting _shooting;

    private void Start()
    {
        _shooting = _enemy.GetComponent<IShooting>();
    }
    
    
    private void Update()
    {
        _shooting.Fire();
    }
}
