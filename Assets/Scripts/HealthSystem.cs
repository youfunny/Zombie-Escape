using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public float armor = 0f;
    public LevelDifficulty levelDifficulty;
    public Zombie zombie;

    private void Start()
    {
        levelDifficulty = FindObjectOfType<LevelDifficulty>();
        zombie = GetComponent<Zombie>();
    }
    public void TakeDamage(float damage, float flatArmorPenetration)
    {
        damage *= 100 / (100 + armor - flatArmorPenetration);
        health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
            if (gameObject.tag.Equals("Zombie"))
            {
                levelDifficulty.ZombiesAlive--;
                levelDifficulty.score += zombie.scoreOnKilled;
                levelDifficulty.scaledDifficulty += zombie.difficultyOnKill;
            }
        }
    }
}
