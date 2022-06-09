using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public PlayerControl player;
    public float maxSpawnCooldown = 40f;
    public float currentCooldown;
    public float range;
    public LevelDifficulty levelDifficulty;
    public float minimumDifficultyToSpawn = 0f;

    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        levelDifficulty = FindObjectOfType<LevelDifficulty>();
    }

    void Update()
    {
        range = Vector3.Distance(transform.position, player.transform.position);
        if (range > 125f && levelDifficulty.scaledDifficulty >= minimumDifficultyToSpawn)
            SpawnZombie();
    }

    void SpawnZombie()
    {
        if (currentCooldown <= 0)
        {
            Instantiate(zombie, gameObject.transform.position, Quaternion.identity);
            levelDifficulty.ZombiesAlive++;
            currentCooldown = Mathf.Clamp(maxSpawnCooldown + levelDifficulty.ZombiesAlive * 0.1f -
                              Mathf.Sqrt(range - 125f), 15f, maxSpawnCooldown);
        }
        else
        {
            currentCooldown = Mathf.Clamp(currentCooldown - 3f * Time.deltaTime, 0, maxSpawnCooldown);
        }
    }
}
