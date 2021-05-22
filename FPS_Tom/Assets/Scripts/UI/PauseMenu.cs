using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private DefaultInput defaultInput;

    public static bool paused = false;
    public static bool upgrading = false;

    public GameObject pauseMenuPanel;
    public GameObject upgradeMenuPanel;

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
        defaultInput.PauseAction.UpgradeMenu.performed += _ => DetermineUpgradeMenu();
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


    public void DetermineUpgradeMenu()
    {
        if (!upgrading)
        {
            OpenUpgradeMenu();
        }
        else
        {
            CloseUpgradeMenu();
        }
    }

    public void OpenUpgradeMenu()
    {
        upgradeMenuPanel.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        upgrading = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseUpgradeMenu()
    {
        upgradeMenuPanel.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        upgrading = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
