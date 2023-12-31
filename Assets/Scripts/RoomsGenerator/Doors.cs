using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private GameObject[] _doors;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var _door in _doors)
            {
                _door.SetActive(true);
            }
            
            FindObjectOfType<BossEnemy>().CanMove = true;
            
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }


    public void OpenDoor()
    {
        foreach (var _door in _doors)
        {
            _door.SetActive(false);
        }
    }
}