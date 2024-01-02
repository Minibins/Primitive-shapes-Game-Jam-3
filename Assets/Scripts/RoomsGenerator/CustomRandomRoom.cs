using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CustomRandomRoom : MonoBehaviour 
{
    public GameObject Prefab;
    public Image Icon;
    public virtual void Spawn(List<Room> _spawnedRooms)
    {

    }
}