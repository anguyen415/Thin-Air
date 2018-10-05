﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string newGameScene;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}