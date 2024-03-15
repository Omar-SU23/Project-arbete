using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;  

    // Update is called once per frame
    void Update()
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
    }

    public void Resume()
    {
      
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Debug.Log("resume");
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void GoToMainMenu(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
  


}
