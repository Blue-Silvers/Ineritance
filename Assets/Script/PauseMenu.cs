using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool gameIsPaused = false;

    [SerializeField] GameObject pauseMenuUI;


    private void Start()
    {
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Paused();
                }

        }
    }
    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        ZooManager.Instance.GameIsPause();
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
        ZooManager.Instance.GameIsPause();
    }

    public void Restart()
    {
        SaveSystem.instance.NewGame();
        Time.timeScale = 1.0f;
        Invoke("LoadScene", 0.1f);
    }

    public void LoadScene()
    {

        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
