using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TMPro.TMP_Text healthMaxValue;

    void Update() {
        int healthMaxValueInt = (int)slider.maxValue;
        healthMaxValue.text = healthMaxValueInt.ToString();
    }

    public void SetUpHealth(float health) 
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void UpdateHealth(float health) 
    {
        slider.value = health;
    }

    public void UpdateMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }
}
