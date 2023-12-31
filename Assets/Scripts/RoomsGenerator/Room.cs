using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Openings _walls;
    [SerializeField] private Openings _transitions;
    public bool isShopRoom;

    public void Setup(HashSet<Vector2Int> _config)
    {
        foreach (var _wall in _walls.GetOpenings())
        {
            bool _contains = _config.Contains(_wall.Pos);
            _wall.GameObject.SetActive(!_contains);
        }

        foreach (var _transition in _transitions.GetOpenings())
        {
            _transition.GameObject.SetActive(false);
        }

        foreach (var _pos in _config)
        {
            foreach (var _transition in _transitions.GetOpenings())
            {
                if (_transition.Pos == _pos)
                {
                    _transition.GameObject.SetActive(true);
                }
            }
        }
    }
}