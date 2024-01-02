using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    public void RestartGame()
    {
        RoomsGenerator.record = -1;
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
