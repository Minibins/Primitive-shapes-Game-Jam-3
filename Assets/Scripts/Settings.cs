using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPanel;
    
    
    public void Setting(bool eneble)
    {
        SettingsPanel.SetActive(eneble);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
