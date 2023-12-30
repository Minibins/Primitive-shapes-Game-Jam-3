using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsGenerator : MonoBehaviour
{
    [SerializeField] private Room _roomPrefab;
    [SerializeField] private int _roomsCount;
    [SerializeField] private int _roomSize;
    [SerializeField] private Transform _roomParent;
    [SerializeField] private GameObject _portalPrefab;
    [SerializeField] private GameObject _shopPrefab;
    [SerializeField] private GameObject[] enemiesPrefabs;

    public List<Room> _spawnedRooms = new List<Room>();

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        Graph graph = new Graph();
        var infos = graph.Generate1(_roomsCount);

        foreach (var pos in infos.Keys)
        {
            var room = Instantiate(_roomPrefab, new Vector3(pos.x, pos.y) * _roomSize, Quaternion.identity, _roomParent);
            
            room.Setup(infos[pos]);
            _spawnedRooms.Add(room);
            yield return 0;
        }

        
        var eligibleRooms = _spawnedRooms.GetRange(1, _spawnedRooms.Count - 2);
        var randomRoom = eligibleRooms[Random.Range(0, eligibleRooms.Count)];
        
        SpawnPortal(_spawnedRooms[_spawnedRooms.Count - 1].transform);

        if (!randomRoom.isShopRoom)
        {
            SpawnRandomShop(randomRoom);
        }
        
        
        for (int i = 1; i < _spawnedRooms.Count - 1; i++)
        {
            if (!_spawnedRooms[i].isShopRoom)
            {
                SpawnEnemies(_spawnedRooms[i].transform);
            }
        }
    }

    
    private void SpawnEnemies(Transform roomTransform)
    {
        int numberOfEnemies = Random.Range(4, 11);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemyPrefab = enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)];
            
            Vector3 randomPosition = roomTransform.position + new Vector3(Random.Range(-9f, 9f), Random.Range(-9f, 9f), 0f);
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity, roomTransform);
        }
    }

    private void SpawnPortal(Transform pos)
    {
        Instantiate(_portalPrefab, pos.position, Quaternion.identity, pos);
    }

    private void SpawnRandomShop(Room _room)
    {
        Instantiate(_shopPrefab, _room.gameObject.transform.position, Quaternion.identity, _room.gameObject.transform);
        _room.isShopRoom = true;
    }
}
