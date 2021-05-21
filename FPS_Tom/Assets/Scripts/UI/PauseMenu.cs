using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private DefaultInput defaultInput;

    public static bool paused = false;

    public GameObject pauseMenuPanel;

    private void Awake()
    {
        defaultInput = new DefaultInput();
    }

    private void OnEnable()
    {
        defaultInput.Enable();
    }

    private void OnDisable()
    {
        defaultInput.Disable();
    }

    private void Start()
    {
        defaultInput.PauseAction.PauseGame.performed += _ => DeterminePause();
        defaultInput.PauseAction.EndGame.performed += _ => EndGame();
    }

    public void DeterminePause()
    {
        if (paused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame() 
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        paused = true;
        Cursor.lockState = CursorLockMode.None;


    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
