using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystem
{
    public float invicibilityTime = 7f;
    public float currentInvicTime = 0f;
    public bool isInvincible = false;
    public float FlooredHealth;
    public float healthRegeneration = 1f;
    public HealthBar healthBar;

    private void Awake()
    {
        currentInvicTime = 12f;
        isInvincible = true;
        healthBar.SetUpHealth(health);
    }
    public void TakeZombieDamage(float amount, float flatArmorPenetration)
    {
        if (!isInvincible)
        {
            TakeDamage(amount, flatArmorPenetration);
            isInvincible = true;
            currentInvicTime = invicibilityTime;
            healthBar.UpdateHealth(health);
        }
    }

    private void Update()
    {
        if (isInvincible)
        {
            currentInvicTime = Mathf.Clamp(currentInvicTime - 3f * Time.deltaTime, 0, invicibilityTime);
            if (currentInvicTime <= 0f)
                isInvincible = false;
        }
        health = Mathf.Clamp(health + Time.deltaTime * 0.25f * healthRegeneration, 0, maxHealth);
        healthBar.UpdateHealth(health);
        healthBar.UpdateMaxHealth(maxHealth);
        FlooredHealth = Mathf.Floor(health);
        healthBar.healthMaxValue.text = FlooredHealth.ToString();
    }
}
