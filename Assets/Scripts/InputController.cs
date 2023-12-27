using UnityEngine;

public class InputController : MonoBehaviour
{
    public static float _horizontalInput;
    public static float _verticalInput;
    
    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }
}
