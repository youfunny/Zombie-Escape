using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = 900;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);

        if (direction.magnitude <= 0)
        {
            //для анимации
        }

        if (Mathf.Abs(direction.y) > 0.1f)
        {
            Vector3 destination = transform.position + transform.right * direction.x + transform.forward * direction.y;
            navMeshAgent.destination = destination;
        }
        else 
        {
            navMeshAgent.destination = transform.position;
            transform.Rotate(0, direction.x * navMeshAgent.angularSpeed * Time.deltaTime, 0);
        }
    }
    //public float speed;
    //PlayerCursor cursor;
    //[SerializeField]
    //public float sprintBoost = 1.5f;
    //public bool isBoosted = false;


    //void Start()
    //{
    //    navMeshAgent = GetComponent<NavMeshAgent>();
    //    cursor = FindObjectOfType<PlayerCursor>();
    //    navMeshAgent.updateRotation = false;
    //}
    //void Update()
    //{
    //    Vector3 forward = cursor.transform.position - transform.position;
    //    transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z));
    //    Vector3 moveDirection = Vector3.zero;
    //    if (Input.GetKey(KeyCode.A))
    //        moveDirection.z = -1.0f;
    //    if (Input.GetKey(KeyCode.D))
    //        moveDirection.z = 1.0f;
    //    if (Input.GetKey(KeyCode.W))
    //        moveDirection.x = -1.0f;
    //    if (Input.GetKey(KeyCode.S))
    //        moveDirection.x = 1.0f;
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        if (!isBoosted)
    //        {
    //            speed *= sprintBoost;
    //            isBoosted = true;
    //        }
    //    }
    //    else
    //    {
    //        if (isBoosted)
    //        {
    //            speed /= sprintBoost;
    //            isBoosted = false;
    //        }
    //    }
    //}
}

