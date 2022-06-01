using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public PlayerControl player;
    public float speed = 5f;
    //public Player player;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //navMeshAgent.SetDestination(Vector3.zero);
        player = FindObjectOfType<PlayerControl>();
        
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
        navMeshAgent.speed = speed;

    }
}
