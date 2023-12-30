using System;
using UnityEngine;

public class LoadSettings : MonoBehaviour
{
    [SerializeField] private String _key;
    public bool valueBool;
    public float valueFloat;

    public virtual void Awake()
    {
        LoadFloat();
        LoadBool();
    }

    public virtual void LoadFloat()
    {
        valueFloat = PlayerPrefs.GetFloat(_key, 0);
    }
    
    protected virtual void LoadBool()
    {
        valueBool =  PlayerPrefs.GetInt(_key) != 0;
        print(valueBool);
    }
}
