using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text score;
    public LevelDifficulty levelDifficulty;

    void Update()
    {
        score.text = levelDifficulty.score.ToString();
    }
}
