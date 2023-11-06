using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
    }

    public void Pausa()
    {
        if (pausePanel.activeInHierarchy && pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else if (pausePanel.activeInHierarchy && settingsMenu.activeInHierarchy)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            pauseMenu.SetActive(true);
            settingsMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            pauseMenu.SetActive(true);
            settingsMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void ResumeButton()
    {
        Pausa();
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
