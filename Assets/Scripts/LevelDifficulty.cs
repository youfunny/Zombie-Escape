using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour
{
    public bool isInfiniteMode;
    public int ZombiesAlive = 0;
    public float scaledDifficulty = 0f;
    public float ticksUntilIncrease = 100f;
    public int score = 0;
    public int difficultyLevel = 0;
    public GamePassedScreen gamePassedScreen;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 1000 && isInfiniteMode == false) 
        {
            score = 0;
            gamePassedScreen.LoadGamePassedScene();
        }
        difficultyLevel = Convert.ToInt32(Math.Floor(scaledDifficulty / 0.15f));
    }

    public void ChillMode() 
    {
        isInfiniteMode = false;
    }

    public void HardcoreMode()
    {
        isInfiniteMode = true;
    }

    private void FixedUpdate()
    {
        if (ticksUntilIncrease > 0)
        {
            ticksUntilIncrease -= Time.deltaTime * 35;
        }
        else
        {
            scaledDifficulty += 0.01f;
            ticksUntilIncrease = 100f;
        }
    }
}
