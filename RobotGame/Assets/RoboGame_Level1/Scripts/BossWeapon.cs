using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float startTime = 2f;
    public float repeatRate = 1f;
    private bool isShooting = false;


    void Start()
    {

    }

    private void OnBecameVisible()
    {
        //Boss schießt
        if (!isShooting)
        {
        InvokeRepeating("BossShoot", startTime, repeatRate);
        }
        
    }
    private void OnBecameInvisible()
    {
        //Boss hört auf zu schießen
        if (isShooting)
        {
            CancelInvoke("BossShoot");
            isShooting=false;
        }
    }
    //Boss Schuss
    void BossShoot()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        isShooting=true;
    }
}
