using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    public int ammo = 12;
    [SerializeField]
    public int maxAmmo = 12;
    [SerializeField]
    public float range = 50f;
    [SerializeField]
    public float damage = 50f;
    [SerializeField]
    public float reloading = 0f;
    [SerializeField]
    public float reloadTime = 100f;
    public bool reloadingNow = false;
    [SerializeField]
    public float reloadSpeed = 1f;
    void Start()
    {
     
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !reloadingNow)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && !reloadingNow)
        {
            reloading = reloadTime;
            reloadingNow = true;
        }
        if (reloadingNow)
            ReloadUpdate();
    }

    void Shoot()
    {
        ammo--;
        Debug.DrawRay(firePoint.position, firePoint.forward * range, Color.blue, 1.5f);
        if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hitInfo, range))
        {
            //Debug.Log(hitInfo.transform.name);
            if (hitInfo.transform.GetComponent<HealthSystem>() != null)
            {
                HealthSystem healthSystem = hitInfo.transform.GetComponent<HealthSystem>();
                healthSystem.TakeDamage(damage);
            }
        }
    }

    void ReloadUpdate()
    {
        reloading = Mathf.Clamp(reloading - 50f * Time.deltaTime * reloadSpeed, 0, reloadTime);
        if (reloading == 0)
        {
            reloadingNow = false;
            ammo = maxAmmo;
        }    
    }
}
