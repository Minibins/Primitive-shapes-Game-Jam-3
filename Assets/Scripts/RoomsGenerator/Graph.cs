using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public class NodeInfo
    {
        public Vector2Int Pos;
        public List<Vector2Int> Dirs;

        public NodeInfo(Vector2Int pos, List<Vector2Int> dirs)
        {
            Pos = pos;
            Dirs = dirs;
        }
    }

    public Dictionary<Vector2Int, HashSet<Vector2Int>> Generate1(int count)
    {
        var _n1 = new Vector2Int(0, 0);

        var _nodes = new Dictionary<Vector2Int, HashSet<Vector2Int>>();
        _nodes.Add(_n1, new HashSet<Vector2Int>());

        var _dxdy = new Vector2Int[]
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(-1, 0)
        };

        var _probs = new Vector2Int[]
        {
            new Vector2Int(0, 25),
            new Vector2Int(25, 50),
            new Vector2Int(50, 75),
            new Vector2Int(75, 100)
        };

        for (int i = 0; i < count - 1; i++)
        {
            bool _next = false;

            while (!_next)
            {
                var _n2 = _n1 + _dxdy[GetIndexWithProb(_probs)];

                if (!_nodes.ContainsKey(_n2))
                {
                    _next = true;

                    _nodes.Add(_n2, new HashSet<Vector2Int>());
                }

                _nodes[_n1].Add(_n2 - _n1);
                _nodes[_n2].Add(_n1 - _n2);

                _n1 = _n2;
            }
        }

        return _nodes;
    }

    private Dictionary<Vector2Int, HashSet<Vector2Int>> CreateGraph(int count)
    {
        var _n1 = new Vector2Int(0, 0);

        var _nodes = new Dictionary<Vector2Int, HashSet<Vector2Int>>();
        _nodes.Add(_n1, new HashSet<Vector2Int>());

        var _dxdy = new Vector2Int[]
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(-1, 0)
        };

        var _probs = new Vector2Int[]
        {
            new Vector2Int(0, 25),
            new Vector2Int(25, 50),
            new Vector2Int(50, 75),
            new Vector2Int(75, 100)
        };

        for (int i = 0; i < count - 1; i++)
        {
            bool _next = false;

            while (!_next)
            {
                var _n2 = _n1 + _dxdy[GetIndexWithProb(_probs)];

                if (!_nodes.ContainsKey(_n2))
                {
                    _next = true;

                    _nodes.Add(_n2, new HashSet<Vector2Int>());
                }

                _nodes[_n1].Add(_n2);
                _nodes[_n2].Add(_n1);

                _n1 = _n2;
            }
        }

        return _nodes;
    }

    private int GetIndexWithProb(Vector2Int[] probs)
    {
        int value = Random.Range(0, 101);

        for (int i = 0; i < probs.Length; i++)
        {
            if (value >= probs[i].x && value < probs[i].y)
            {
                return i;
            }
        }

        return 0;
    }
}