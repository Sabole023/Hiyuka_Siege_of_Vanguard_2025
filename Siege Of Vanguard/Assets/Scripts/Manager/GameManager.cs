using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager main;

    [Header("Game State")]
    public bool isPlaying = false;
    public bool isPaused = false;

    private void Awake()
    {
        main = this;
    }

    public void Play()
    {

    }

    public void Pause()
    {

    }

    public void GameOver()
    {

    }
}
