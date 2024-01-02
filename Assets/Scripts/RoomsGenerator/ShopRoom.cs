using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ShopRoom : CustomRandomRoom
{
    public override void Spawn(List<Room> _spawnedRooms)
    {
        Room room = _spawnedRooms[Random.Range(0,_spawnedRooms.Count)];
        room.isPeacefulRoom = true;
        Instantiate(Prefab,room.gameObject.transform.position,Quaternion.identity,room.gameObject.transform);
        room.Icon = Icon;
    }
}
