using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameUI;
    
    public static GameOverScreen Instance {get; set;}

    void Start()
    {
        gameOverUI.SetActive(false);    
    }
    
    private void Awake()
    {
        Instance = this;
    }

    public void LoadGameOverScene() 
    {
        Cursor.visible = true;
        gameUI.SetActive(false);
        Time.timeScale = 0f;  
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        gameUI.SetActive(true);
        gameOverUI.SetActive(false);
        Time.timeScale = 1f; 
        Cursor.visible = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}