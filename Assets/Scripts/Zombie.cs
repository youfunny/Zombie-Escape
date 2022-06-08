using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public PlayerControl player;
    public HealthSystem healthSystem;
    public float speed = 24f;
    public bool enrageable = false;
    public bool enraged = false;
    public float enrageBoost = 1.3f;
    public float collisionDamage = 20f;
    public PlayerHealth playerHealthSystem;
    

    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerControl>();
        playerHealthSystem = player.GetComponent<PlayerHealth>();
        navMeshAgent.speed = speed;
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
        playerHealthSystem.TakeZombieDamage(collisionDamage);
        
    }

}
