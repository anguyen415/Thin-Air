using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource source;
    public AudioClip open;
    public AudioClip close;
    public bool played;

    public Text DeathText;

    public GameObject ResumeButton;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
        Resume();
        DeathText.gameObject.SetActive(false);
        ResumeButton.SetActive(true);
        played = false;
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
                source.PlayOneShot(close, .1f);
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
			StartCoroutine(DeathMenu());
		}
	}

	public IEnumerator DeathMenu()
	{
		yield return new WaitForSeconds(5f);
		Time.timeScale = 0f;
		ResumeButton.SetActive(false);
		DeathText.gameObject.SetActive(true);
		Pause();

	}

	public void Resume()
    {
        if (!played)
        {
            source.PlayOneShot(open, .1f);
        }
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
        SceneManager.LoadScene("InfirmaryLevel");
    }
}
