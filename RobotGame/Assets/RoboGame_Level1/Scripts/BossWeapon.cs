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
        //Boss schie�t
        if (!isShooting)
        {
        InvokeRepeating("BossShoot", startTime, repeatRate);
        }
        
    }
    private void OnBecameInvisible()
    {
        //Boss h�rt auf zu schie�en
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
