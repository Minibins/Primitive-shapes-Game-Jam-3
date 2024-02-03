using UnityEngine;
using System.Collections.Generic;
public class MinimapController : BetterBehavior
{
    Transform player;
    [SerializeField] float roomScale;
    private void Awake()
    {
        player = FindObjectOfType<Player>().transform;
    }
    Vector3 lastPlayerPosition = Vector3.zero;
    private void FixedUpdate()
    {
        
        foreach(var room in children)
            room.transform.position += roomScale * (player.position - lastPlayerPosition);
        lastPlayerPosition = player.position;
    }
}
