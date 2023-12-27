using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject _gunSwipe;
    [SerializeField] private GameObject SettingsPanel;
    private IShooting _shooting;
    public static float _horizontalInput;
    public static float _verticalInput;


    private void Start()
    {
        _shooting = _gunSwipe.GetComponent<IShooting>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _shooting.Fire();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsPanel.GetComponent<Settings>().Setting(true);
        }

        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }
}
