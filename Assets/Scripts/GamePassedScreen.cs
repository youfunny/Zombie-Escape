using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePassedScreen : MonoBehaviour
{
    public GameObject gamePassedUI;
    public GameObject gameUI;
    
    public static GamePassedScreen Instance {get; set;}

    void Start()
    {
        gamePassedUI.SetActive(false);    
    }
    
    private void Awake()
    {
        Instance = this;
    }

    public void LoadGamePassedScene() 
    {
        Cursor.visible = true;
        gameUI.SetActive(false);
        Time.timeScale = 0f;  
        gamePassedUI.SetActive(true);
    }

    public void RestartGame()
    {
        gameUI.SetActive(true);
        gamePassedUI.SetActive(false);
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