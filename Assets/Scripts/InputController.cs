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
    public static bool _Ebutton;

    public Joystick _moveJoystick;
    public Joystick _fireJoystick;

    [SerializeField] private bool _isAndroid;
    public static bool IssAndroid;
    public static float _horizontalJoystickInput;
    public static float _verticalJoystickInput;


    private void Start()
    {
        _shooting = _gunSwipe.GetComponent<IShooting>();

        _moveJoystick.gameObject.SetActive(_isAndroid);
        _fireJoystick.gameObject.SetActive(_isAndroid);
    }

    private void Update()
    {
        IssAndroid = _isAndroid;


        if (Input.GetKeyDown(KeyCode.E))
        {
            EButton(true);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            EButton(false);
        }
        
        if (!_isAndroid)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _shooting.SingleFire();
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                _shooting.Fire();
            }
        }

        else if (_fireJoystick.Horizontal > 0 || _fireJoystick.Horizontal < 0 || _fireJoystick.Vertical > 0 ||
                 _fireJoystick.Vertical < 0)
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            _statsPanel.SetActive(!_statsPanel.activeSelf);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPauseMenu();
        }

        var _scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (_scrollWheel > 0f)
        {
            _shooting.SwipeUpGun();
        }
        else if (_scrollWheel < 0f)
        {
            _shooting.SwipeDownGun();
        }


        if (_isAndroid)
        {
            _horizontalInput = _moveJoystick.Horizontal;
            _verticalInput = _moveJoystick.Vertical;

            _horizontalJoystickInput = _fireJoystick.Horizontal;
            _verticalJoystickInput = _fireJoystick.Vertical;
        }
        else
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
        }
    }

    public void EButton(bool enable)
    {
        _Ebutton = enable;
    }


    public void SetActiveJoysticks(bool enable)
    {
        _moveJoystick.gameObject.SetActive(enable);
        _fireJoystick.gameObject.SetActive(enable);
    }

    public void OpenPauseMenu()
    {
        SetActiveJoysticks(false);
        SettingsPanel.GetComponent<Settings>().PauseMenu(true);
    }

    public void Fire()
    {
        _shooting.Fire();
    }
}