using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _pauseMenu;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _settingsPanel.SetActive(true);
        _settingsPanel.SetActive(false);
    }

    public void PauseMenu(bool eneble)
    {
        _pauseMenu.SetActive(eneble);

        Scene _currenScene = SceneManager.GetActiveScene();

        if (_currenScene.name == "Game")
        {
            if (eneble)
                Time.timeScale = 0f;
            else
                Time.timeScale = 1f;
        }
    }

    public void SettingsMenu(bool eneble)
    {
        _settingsPanel.SetActive(eneble);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
