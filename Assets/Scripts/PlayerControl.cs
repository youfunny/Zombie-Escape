using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    private bool isBoosted = false;
    public float sprintBoost = 1.35f;
    //1.50 38
    [SerializeField]
    public float energy;
    [SerializeField]
    public float maxEnergy = 100f;
    [SerializeField]
    public float sprintCooldown = 0;
    [SerializeField]
    public float exhaustedTime = 100f;
    
    void Start()
    {
        energy = maxEnergy;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);
        if (Input.GetKey(KeyCode.LeftShift) && sprintCooldown == 0)
        {
            if (!isBoosted)
            {
                navMeshAgent.speed *= sprintBoost;
                isBoosted = true;
            }
            energy = Mathf.Clamp(energy - 13f * Time.deltaTime, 0, maxEnergy);
            if (energy <= 0)
                sprintCooldown = 100f;
        }
        else
        {
            if (isBoosted)
            {
                navMeshAgent.speed /= sprintBoost;
                isBoosted = false;
            }
            energy = Mathf.Clamp(energy + 5.5f * Time.deltaTime, 0, maxEnergy);
        }

        if (direction.magnitude <= 0)
        {
            //для анимации
        }

        if (Mathf.Abs(direction.y) > 0.01f || Mathf.Abs(direction.x) > 0.01f)
        {
            Vector3 destination = transform.position + transform.right * direction.x * 1.01f + transform.forward * direction.y * 1.01f;
            navMeshAgent.destination = destination;
        }
        else 
        {
            navMeshAgent.destination = transform.position;
            transform.Rotate(0, direction.x * navMeshAgent.angularSpeed * Time.deltaTime, 0);
        }
    }

    private void FixedUpdate()
    {
        sprintCooldown = Mathf.Clamp(sprintCooldown - 17f * Time.deltaTime, 0, exhaustedTime);
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

