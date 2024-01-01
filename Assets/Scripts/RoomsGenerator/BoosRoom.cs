using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoosRoom : Room
{
    [SerializeField] private GameObject[] _bosses;
    
    [SerializeField] private Doors _doors;
    [SerializeField] GameObject portalPrefab;

    private void Start()
    {
        InstantiateBoss();
    }

    private void InstantiateBoss()
    {
        int _randomBoss = Random.Range(0, _bosses.Length);
        GameObject _boss = Instantiate(_bosses[_randomBoss], transform.position,
            Quaternion.identity, transform);


        
        _boss.GetComponent<BossEnemy>().CanMove = false;
        _boss.GetComponent<BossEnemy>()._bossRoom = this;
    }

    public void BossDie()
    {
        _doors.OpenDoor();
        Instantiate(portalPrefab, transform.position, Quaternion.identity);

    }
}