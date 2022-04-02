using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
	//Происходит каждый кадр
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Resume();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ShowPanel(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void HidePanel(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
