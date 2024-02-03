using System.Collections.Generic;

using UnityEngine;

public class BetterBehavior : MonoBehaviour
{
    protected Transform[] children
    {
        get
        {
            List<Transform> childlist = new();
            for (int i = 0; i < transform.childCount; i++) 
            { 
                childlist.Add( transform.GetChild(i));
            }
            return childlist.ToArray();
        }                
    }
    new protected Transform transform;
    protected virtual void OnEnable()
    {
        transform = base.transform;
    }
}
