using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    public void RestartGame()
    {
        PlayerPrefs.SetInt("record", RoomsGenerator.record);
        RoomsGenerator.record = -1;
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    
}
