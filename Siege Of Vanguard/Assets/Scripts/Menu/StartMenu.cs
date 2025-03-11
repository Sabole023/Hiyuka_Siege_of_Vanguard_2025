using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartNewGame()
    {
        Debug.Log("Start new game");
        SceneManager.LoadScene("LobbyScene");
    }

    public void StartContinuedGame()
    {
        Debug.Log("Continue game");
        SceneManager.LoadScene("LobbyScene");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
