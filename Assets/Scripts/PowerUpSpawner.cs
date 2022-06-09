using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public PowerUp powerUpDamage;
    public PowerUp powerUpHealth;
    public PowerUp powerUpSpeed;
    public PowerUp powerUpPenetrating;
    public PowerUp powerUp;
    public PlayerControl player;
    public float spawnCooldown = 85f;
    public float currentCooldown = 0f;
    public bool isSpawned = false;

    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
    }

    void Update()
    {
        var distance = Vector3.Distance(transform.position, player.transform.position);
        if (currentCooldown > 0f && !isSpawned)
        {
            currentCooldown = Mathf.Clamp(currentCooldown - 3f * Time.deltaTime, 0, spawnCooldown);
        }
        else if (!isSpawned)
        {
            ChoosePowerUp();
            Instantiate(powerUp, gameObject.transform.position, Quaternion.identity);
            isSpawned = true;
            currentCooldown = spawnCooldown;
        }

        if (distance < 10.5f && isSpawned)
        {
            isSpawned = false;
        }
    }

    public void ChoosePowerUp()
    {
        int powerNum = Random.Range(0, 4);
        if (powerNum == 0)
            powerUp = powerUpDamage;
        else if (powerNum == 1)
            powerUp = powerUpHealth;
        else if (powerNum == 2)
            powerUp = powerUpSpeed;
        else
            powerUp = powerUpPenetrating;
    }
}
