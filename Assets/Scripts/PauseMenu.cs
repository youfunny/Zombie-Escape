using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

     void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
       {
           if(isPaused)
           {
               ResumeGame();
           }else
           {
               PauseGame();
           }
       }
    }

    void PauseGame()
    {
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        isPaused=false;
    }

    public void GoToMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
