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

    public float soundVolume = 0.25f;
    public AudioSource musicSource;
    public AudioSource playerBulletSource;
    public AudioSource[] EnemyBulletSource;

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

        UpdateVolume(soundVolume);
        musicSource.volume = soundVolume;
        playerBulletSource.volume = soundVolume;
        foreach (var enemyAudio in EnemyBulletSource)
        {
            if (enemyAudio != null)
            {
                enemyAudio.volume = soundVolume;
            }

        }

    }

    private void Update()
    {
        musicSource.volume = soundVolume;
        playerBulletSource.volume = soundVolume;
        foreach (var enemyAudio in EnemyBulletSource)
        {
            if (enemyAudio != null)
            {
                enemyAudio.volume = soundVolume;
            }
            
        }
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


    public void UpdateVolume(float volume)
    {
        soundVolume = volume;
    }
}
