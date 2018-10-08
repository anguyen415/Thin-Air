using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    public Text DeathText;

    public GameObject ResumeButton;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
        Resume();
        DeathText.gameObject.SetActive(false);
        ResumeButton.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
        /*if ((player.GetComponent("Oxygen") as Oxygen).CurrentOxygen == 0)
        {
            restartButton.SetActive(true);
        }
        else
        {
            restartButton.SetActive(false);
        }*/
	}

    void FixedUpdate()
    {
        
        if (Oxygen.CurrentOxygen <= 0)
        {
            Time.timeScale = 0f;
            ResumeButton.SetActive(false);
            DeathText.gameObject.SetActive(true);
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
