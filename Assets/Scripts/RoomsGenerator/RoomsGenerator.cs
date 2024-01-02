using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoomsGenerator : MonoBehaviour
{
    [SerializeField] private Room _roomPrefab;
    [SerializeField] private Room _lastRoomPrefab;
    [SerializeField] private int _roomsCount;
    [SerializeField] private int _roomSize, _minimapRoomSize;
    [SerializeField] private Transform _roomParent;
    [SerializeField] private GameObject[] enemiesPrefabs;
    [SerializeField] private CustomRandomRoom[] rooms;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Text _youBeatText;
    public static int record = -1;
    public List<Room> _spawnedRooms = new List<Room>();

    public void Start()
    {
        record++;
        _youBeatText.text = $"You beat {record} floors";
        for(int i = 0; i < _roomParent.childCount; i++)
        {
            Destroy(_roomParent.GetChild(i).gameObject);
        }
        for(int i = 0; i < _rectTransform.childCount; i++)
        {
            Destroy(_rectTransform.GetChild(i).gameObject);
        }
        _spawnedRooms.Clear();
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        Graph graph = new Graph();
        var infos = graph.Generate1(_roomsCount);

        var keysList = new List<Vector2Int>(infos.Keys);

        foreach (var pos in keysList)
        {
            var roomPrefab = (pos == keysList[keysList.Count - 1]) ? _lastRoomPrefab : _roomPrefab;
            var room = Instantiate(roomPrefab, new Vector3(pos.x, pos.y) * _roomSize+transform.position, Quaternion.identity, _roomParent);
            room.Icon = Instantiate(room.Icon, _rectTransform.position+new Vector3(pos.x,pos.y)*_minimapRoomSize, Quaternion.identity, _rectTransform);
            room.Setup(infos[pos]);
            _spawnedRooms.Add(room);
        }

        var eligibleRooms = _spawnedRooms.GetRange(1, _spawnedRooms.Count - 2);
        var randomRoom = eligibleRooms[Random.Range(0, eligibleRooms.Count)];
        

        foreach (var room in rooms)
        {
            room.Spawn(_spawnedRooms);
        }

        for (int i = 1; i < _spawnedRooms.Count - 1; i++)
        {
            if (!_spawnedRooms[i].isPeacefulRoom)
            {
                StartCoroutine(SpawnEnemies(_spawnedRooms[i].transform));
            }
        }
        yield return new WaitForEndOfFrame();
    }

    private IEnumerator SpawnEnemies(Transform roomTransform)
    {
        int numberOfEnemies = Random.Range(4, 11);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemyPrefab = enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)];
            yield return new WaitForSeconds(0.4f);
            Vector3 randomPosition = roomTransform.position + new Vector3(Random.Range(-9f, 9f), Random.Range(-9f, 9f), 0f);
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity, roomTransform);
        }
    }
}
