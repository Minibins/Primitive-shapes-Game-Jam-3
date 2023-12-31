using System.Collections;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject _gunSwipe;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject _statsPanel;
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
            _shooting.SingleFire();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            _shooting.Fire();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            _statsPanel.SetActive(!_statsPanel.activeSelf);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsPanel.GetComponent<Settings>().PauseMenu(true);
        }

        float _scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (_scrollWheel > 0f)
        {
            _shooting.SwipeUpGun();
        }
        else if (_scrollWheel < 0f)
        {
            _shooting.SwipeDownGun();
        }


        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }
}