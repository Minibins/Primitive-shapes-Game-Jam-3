using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject SettingsMenu;

    [SerializeField] private Text _recordText;

    private void Awake()
    {
        SettingsMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        
        _recordText.text =  $"You beat {PlayerPrefs.GetInt("record",0)} floors";
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
