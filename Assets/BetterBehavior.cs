using UnityEngine;

public class BetterBehavior : MonoBehaviour
{
    new protected Transform transform;
    private void Start()
    {
        transform = base.transform;
    }
}
