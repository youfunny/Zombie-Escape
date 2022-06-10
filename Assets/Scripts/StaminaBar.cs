using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public PlayerControl player;
    void Start()
    {
        slider.minValue = 0f;
        slider.maxValue = 100f;
    }

    void Update()
    {
        slider.value = player.energy;
    }
}
