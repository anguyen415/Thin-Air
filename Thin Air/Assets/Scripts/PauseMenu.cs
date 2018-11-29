using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource source;
	public AudioSource Music;
	public GameObject playerSound;
	public AudioClip deathMusic;
	public AudioClip open;
    public AudioClip close;
    public bool played;

	private bool Dead = false;
	GameObject player;

    public Text DeathText;

    public GameObject ResumeButton;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
        Resume();
        DeathText.gameObject.SetActive(false);
        ResumeButton.SetActive(true);
        played = false;

		player = GameObject.FindGameObjectWithTag("Player");

	}

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Dead)
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

		if (Oxygen.CurrentOxygen <= 0 && !Dead)
		{
			Dead = true;
			StartCoroutine(DeathMenu());
		}
	}

	public IEnumerator DeathMenu()
	{
		playerSound.active = false;
		player.GetComponent<PlayerMovement_anh>().enabled = false;
		Music.Stop();
		Music.clip = deathMusic;
		Music.loop = false;
		Music.volume = 0.8f;
		Music.Play();
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
