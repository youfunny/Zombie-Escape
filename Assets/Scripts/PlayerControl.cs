using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float speed;
    PlayerCursor cursor;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //cursor = FindObjectOfType<PlayerCursor>();
        //navMeshAgent.updateRotation = false;
    }
    void Update()
    {
        //Vector3 forward = cursor.transform.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z));
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
            moveDirection.z = -1.0f;
        if (Input.GetKey(KeyCode.D))
            moveDirection.z = 1.0f;
        if (Input.GetKey(KeyCode.W))
            moveDirection.x = -1.0f;
        if (Input.GetKey(KeyCode.S))
            moveDirection.x = 1.0f;
        navMeshAgent.velocity = moveDirection.normalized * speed;
    }
}

