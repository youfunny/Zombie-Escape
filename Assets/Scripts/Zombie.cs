using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public PlayerControl player;
    public HealthSystem healthSystem;
    public float speed = 22f;
    public bool enrageable = false;
    public bool enraged = false;
    public float enrageBoost = 1.3f;
    public float collisionDamage = 20f;
    public PlayerHealth playerHealthSystem;
    public int scoreOnKilled = 10;
    public float difficultyOnKill = 0f;
    public LevelDifficulty levelDifficulty;
    public float speedPerLvl = 1f;
    public float enrageBoostPerLvl = 0.01f;
    public float collisionDamagePerLvl = 1f;
    public float healthPerLvl = 1f;

    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerControl>();
        levelDifficulty = FindObjectOfType<LevelDifficulty>();
        playerHealthSystem = player.GetComponent<PlayerHealth>();
        navMeshAgent.speed = speed;
        ScaleStats();
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
        if (enrageable && healthSystem.health < healthSystem.maxHealth && !enraged)
        {
            navMeshAgent.speed *= enrageBoost;
            enraged = true;
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log(collision.transform);
        //playerHealthSystem = collision.transform.GetComponent<PlayerHealth>();
        if (collision.transform.tag.Equals("Player"))
            playerHealthSystem.TakeZombieDamage(collisionDamage);
        
    }

    void ScaleStats()
    {
        var lvl = levelDifficulty.difficultyLevel;
        speed += speedPerLvl * lvl;
        enrageBoost += enrageBoostPerLvl * lvl;
        collisionDamage += collisionDamagePerLvl * lvl;
        healthSystem.maxHealth += healthPerLvl * lvl;
        healthSystem.health = healthSystem.maxHealth;
    }

}
