using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;
   

    
    void Update()
    {
        //When the player presses escape the game pauses
        if (Input.GetKeyDown(KeyCode.Escape));
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        
    }

    // When the game pauses the UI for the PauseMenu appears
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // When the game resumes the UI for the PauseMenu disappears
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    // When the player presses Menu it takes the player to the menu
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    // When the player presses quit game the game closes
    public void QuitGame()
    {
        Application.Quit();
    }
}
