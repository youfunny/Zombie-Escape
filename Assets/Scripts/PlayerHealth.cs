using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystem
{
    public float invicibilityTime = 7f;
    public float currentInvicTime = 0f;
    public bool isInvincible = false;
    public double FlooredHealth;
    public float healthRegeneration = 1f;

    private void Awake()
    {
        currentInvicTime = 12f;
        isInvincible = true;
    }
    public void TakeZombieDamage(float amount, float flatArmorPenetration)
    {
        if (!isInvincible)
        {
            TakeDamage(amount, flatArmorPenetration);
            isInvincible = true;
            currentInvicTime = invicibilityTime;
        }
    }

    private void Update()
    {
        if (isInvincible)
        {
            currentInvicTime = Mathf.Clamp(currentInvicTime - 3f * Time.deltaTime, 0, 100f);
            if (currentInvicTime <= 0f)
                isInvincible = false;
        }
        health = Mathf.Clamp(health + Time.deltaTime * 0.25f * healthRegeneration, 0, maxHealth);
        FlooredHealth = Mathf.Floor(health);
    }
}
