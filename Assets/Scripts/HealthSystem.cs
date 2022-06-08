using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public float armor = 0f;

    public void TakeDamage(float damage)
    {
        damage *= 100 / (100 + armor);
        health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0f)
            Destroy(gameObject);
    }
}
