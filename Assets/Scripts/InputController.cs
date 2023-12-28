using System.Collections;

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
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _shooting.Fire();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsPanel.GetComponent<Settings>().PauseMenu(true);
        }
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }
    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            if(Input.GetMouseButton(0))
            {
                _shooting.Fire();
            }
        }
    }
}
