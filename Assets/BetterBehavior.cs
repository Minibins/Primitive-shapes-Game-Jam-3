using UnityEngine;

public class BetterBehavior : MonoBehaviour
{
    new protected Transform transform;
    protected virtual void OnEnable()
    {
        transform = base.transform;
    }
}
