using System;
using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    [SerializeField] private String _key;

    public virtual void SaveFloat(float _var)
    {
        PlayerPrefs.SetFloat(_key,_var);
    }
    
    public virtual void SaveBool(bool _var)
    {
        PlayerPrefs. SetInt(_key, (_var ? 1 : 0));
    }
}
