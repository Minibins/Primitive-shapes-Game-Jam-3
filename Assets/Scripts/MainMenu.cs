using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject SettingsMenu;
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Settings(bool eneble)
    {
        SettingsMenu.SetActive(eneble);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
