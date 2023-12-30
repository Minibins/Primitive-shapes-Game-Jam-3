using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject SettingsMenu;

    private void Awake()
    {
        SettingsMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

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
