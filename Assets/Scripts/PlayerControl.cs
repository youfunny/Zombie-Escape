using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerControl : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    private bool isBoosted = false;
    public float sprintBoost = 1.5f;
    public float speed = 38f;
    //1.50 38
    [SerializeField]
    public float energy;
    [SerializeField]
    public float maxEnergy = 100f;
    [SerializeField]
    public float sprintCooldown = 0;
    [SerializeField]
    public float exhaustedTime = 100f;
    public float rotateSpeed;
    public bool isAiming = false;
    public float aimingRotateSpeed = 60f;
    public float energyRecoveryMulti = 1f;
    public float energyUsageMulti = 1f;

    void Start()
    {
        energy = maxEnergy;
        navMeshAgent = GetComponent<NavMeshAgent>();
        rotateSpeed = navMeshAgent.angularSpeed;
        Cursor.visible = false;
        navMeshAgent.speed = speed;
    }

    void Update()
    {
        navMeshAgent.speed = speed;
        if (Input.GetKeyDown(KeyCode.K))
        {
            Cursor.visible = !Cursor.visible;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (!isAiming)
            {
                navMeshAgent.angularSpeed = aimingRotateSpeed;
                isAiming = true;
            }
        }
        else
        {
            if (isAiming)
            {
                navMeshAgent.angularSpeed = rotateSpeed;
                isAiming = false;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) && sprintCooldown == 0)
        {
            if (!isBoosted)
            {
                navMeshAgent.speed *= sprintBoost;
                speed = navMeshAgent.speed;
                isBoosted = true;
            }
            energy = Mathf.Clamp(energy - 13f * Time.deltaTime * energyUsageMulti, 0, maxEnergy);
            if (energy <= 0)
                sprintCooldown = exhaustedTime;
        }
        else
        {
            if (isBoosted)
            {
                navMeshAgent.speed /= sprintBoost;
                speed = navMeshAgent.speed;
                isBoosted = false;
            }
            energy = Mathf.Clamp(energy + 5.5f * Time.deltaTime * energyRecoveryMulti, 0, maxEnergy);
        }

        if (direction.magnitude == 0)
        {
          //для анимации   
        }

        if (Mathf.Abs(direction.y) > 0.01f || Mathf.Abs(direction.x) > 0.01f)
        {
            navMeshAgent.isStopped = false;
            Vector3 destination = transform.position + transform.right * direction.x * 1.01f + transform.forward * direction.y * 1.01f;
            navMeshAgent.destination = destination;
        }
        else
        {
            //navMeshAgent.destination = transform.position;
            navMeshAgent.isStopped = true;
            //transform.Rotate(0, direction.x * navMeshAgent.angularSpeed * Time.deltaTime, 0);
        }
    }

    private void FixedUpdate()
    {
        sprintCooldown = Mathf.Clamp(sprintCooldown - 17f * Time.deltaTime, 0, exhaustedTime);
    }
}

