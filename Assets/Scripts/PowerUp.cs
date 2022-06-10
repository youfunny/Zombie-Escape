using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerType 
    {
        Damage,        //+����, ������, �������� ����������� � �������
        Health,        //+���� �� � �����. ��������� ����������� ��. +invicibility time
        Speed,         //+�������� ������ � ����. +������������ -������ ����
        Penetrating    //+����� � +����� ��������
    }
    public PowerType powerType;
    public ShootingSystem playerShootingSystem;
    public PlayerHealth playerHealthSystem;
    public PlayerControl playerControl;
    public PowerUpSpawner powerUpSpawner;
    public LevelDifficulty levelDifficulty;
    public float distance;

    void Start()
    {
        playerShootingSystem = FindObjectOfType<ShootingSystem>();
        playerHealthSystem = FindObjectOfType<PlayerHealth>();
        playerControl = FindObjectOfType<PlayerControl>();
        levelDifficulty = FindObjectOfType<LevelDifficulty>();
    }

    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, playerControl.transform.position);
        if (distance <= 10f)
        {
            if (powerType == PowerType.Damage)
            {
                playerShootingSystem.maxAmmo++;
                playerShootingSystem.range += 25f;
                playerShootingSystem.damage += 2;
                playerShootingSystem.reloadSpeed += 0.06f;
            }
            else if (powerType == PowerType.Health)
            {
                playerHealthSystem.maxHealth += 10f;
                playerHealthSystem.health = Mathf.Clamp(playerHealthSystem.health + 25f, 0, playerHealthSystem.maxHealth);
                playerHealthSystem.healthRegeneration += 0.1f;
                playerHealthSystem.invicibilityTime += 0.4f;
            }
            else if (powerType == PowerType.Speed)
            {
                playerControl.speed += 1.5f;
                playerControl.sprintBoost += 0.04f;
                playerControl.energyRecoveryMulti += 0.02f;
                playerControl.energyUsageMulti -= 0.02f;
                playerControl.exhaustedTime = Mathf.Clamp(playerControl.exhaustedTime - 5f, 0, 1000f);
            }
            else if (powerType == PowerType.Penetrating)
            {
                playerHealthSystem.armor += 6f;
                playerShootingSystem.flatArmorPenetration += 6f;
            }
            else
                return;
            levelDifficulty.score += 15;
            Destroy(gameObject);
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.transform.tag.Equals("Player"))
    //    {
    //        if (powerType == PowerType.Damage)
    //        {
    //            playerShootingSystem.maxAmmo++;
    //            playerShootingSystem.range += 25f;
    //            playerShootingSystem.damage += 2;
    //            playerShootingSystem.reloadSpeed += 0.06f;
    //        }
    //        else if (powerType == PowerType.Health)
    //        {
    //            playerHealthSystem.maxHealth += 10f;
    //            playerHealthSystem.health = Mathf.Clamp(playerHealthSystem.health + 25f, 0, playerHealthSystem.maxHealth);
    //            playerHealthSystem.healthRegeneration += 1.07f;
    //            playerHealthSystem.invicibilityTime += 0.4f;
    //        }
    //        else if (powerType == PowerType.Speed)
    //        {
    //            playerControl.speed += 1.5f;
    //            playerControl.sprintBoost += 0.04f;
    //            playerControl.energyRecoveryMulti += 0.02f;
    //            playerControl.energyUsageMulti -= 0.02f;
    //            playerControl.exhaustedTime = Mathf.Clamp(playerControl.exhaustedTime - 5f, 0, 1000f);
    //        }
    //        else if (powerType == PowerType.Penetrating)
    //        {
    //            playerHealthSystem.armor += 6f;
    //            playerShootingSystem.flatArmorPenetration += 6f;
    //        }
    //        else
    //            return;
    //        Destroy(gameObject);
    //    }
    //}
}
