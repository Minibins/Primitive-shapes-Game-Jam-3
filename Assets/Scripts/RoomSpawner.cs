using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private Direction direction;

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right,
        Mone
    }

    private RoomVariants _variants;
    private Transform _grid;
    private int _rand;
    private bool _spawned = false;
    private float _waitTime = 3f;


    private void Start()
    {
        _variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        _grid =  GameObject.FindGameObjectWithTag("Grid").GetComponent<Transform>();
        Destroy(gameObject,_waitTime);
        Invoke("Spawn",0.2f);
    }

    public void Spawn()
    {
        if (!_spawned)
        {
            switch (direction)
            {
                case Direction.Top:
                    _rand = Random.Range(0, _variants.topRooms.Length);
                    Instantiate(_variants.topRooms[_rand], transform.position, _variants.topRooms[_rand].transform.rotation, _grid);
                    break;
                case Direction.Bottom:
                    _rand = Random.Range(0, _variants.bottomRooms.Length);
                    Instantiate(_variants.bottomRooms[_rand], transform.position, _variants.bottomRooms[_rand].transform.rotation, _grid);
                    break;
                case Direction.Right:
                    _rand = Random.Range(0, _variants.rightRooms.Length);
                    Instantiate(_variants.rightRooms[_rand], transform.position, _variants.rightRooms[_rand].transform.rotation,_grid);
                    break;
                case Direction.Left:
                    _rand = Random.Range(0, _variants.leftRooms.Length);
                    Instantiate(_variants.leftRooms[_rand], transform.position, _variants.leftRooms[_rand].transform.rotation,_grid);
                    break;
            }
            _spawned = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("RoomPoint") && other.GetComponent<RoomSpawner>()._spawned)
        {
            Destroy(gameObject);
        }
    }
}