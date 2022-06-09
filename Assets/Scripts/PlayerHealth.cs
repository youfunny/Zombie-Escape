using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystem
{
    public float invicibilityTime = 7f;
    public float currentInvicTime = 0f;
    public bool isInvincible = false;
    public double FlooredHealth;

    private void Awake()
    {
        currentInvicTime = 12f;
        isInvincible = true;
    }
    public void TakeZombieDamage(float amount)
    {
        if (!isInvincible)
        {
            TakeDamage(amount);
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
        health = Mathf.Clamp(health + Time.deltaTime * 0.25f, 0, maxHealth);
        FlooredHealth = Mathf.Floor(health);
    }
}
