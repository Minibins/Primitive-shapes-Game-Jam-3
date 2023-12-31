using UnityEngine;
using Random = UnityEngine.Random;

public class BoosRoom : Room
{
    [SerializeField] private GameObject[] _bosses;

    [SerializeField] private Doors _doors;
    private void Start()
    {
        InstantiateBoss();
    }

    private void InstantiateBoss()
    {
        GameObject _boss = Instantiate(_bosses[Random.Range(0, _bosses.Length)], transform.position,
            Quaternion.identity, transform);

        
        _boss.GetComponent<BossEnemy>().CanMove = false;
        _boss.GetComponent<BossEnemy>()._boosRoom = this;
    }

    public void BossDie()
    {
        _doors.OpenDoor();
    }
    
    
}