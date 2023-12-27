using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Transform instance;
    void Start()
    {
        instance = transform;
    }
}
