using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool isShooting = false;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject pulsePrefab;
    public GameObject superGunPrefab;
    public Animator animator;
    public PickUpUI pickUpUI;
    public float pulseReset = 30f;
    public float delay = 2f;
    private bool fire = false;
    private bool pulse = false;
    private bool superGun = false;


    private void Start()
    {
        pickUpUI = FindAnyObjectByType<PickUpUI>();
        pickUpUI.SetSliderSuper(0);
        pickUpUI.SetSliderPulse(0);
    }

    // Update is called once per frame
    void Update()
    {
       
        //Schießen
        if (Input.GetButtonDown("Fire1")  && !isShooting && !pulse && !superGun)
        {
            fire = true;
            
        }

        //Schießen pulse
        if(Input.GetButtonDown("Fire1") && !isShooting && pulse && !superGun)
        {
            
            fire = true;
        }

        //Schießen Supergun
        if(Input.GetButtonDown("Fire1") && !isShooting && superGun)
        {
            fire = true;
        }
       
    }

    void FixedUpdate()
    {
        //Schießen ausführen und Frequenz beschränken
        if (fire) 
        {
            Shoot();
            
            Invoke("AllowShot", delay * Time.fixedDeltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Puls Pickup
        if (collision.gameObject.CompareTag("PulsePickup"))
        {
            pulse = true;
            delay /= 2;
            pickUpUI.SetSliderPulse(1);
            Invoke("ResetPulse", pulseReset);
            
        }

        //Supergun Pickup
        if (collision.gameObject.CompareTag("SuperGun"))
        {
            pickUpUI.SetSliderSuper(1);
            superGun = true;
            delay /= 2;

        }
    }

    //Schuss
    void Shoot()
    {
        //Normaler Schuss
        if (!pulse && !superGun)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            isShooting = true;
            animator.SetBool("IsShooting", true);
            fire = false;
        }
        //Pulse Schuss
        if (pulse && !superGun)
        {
            Instantiate(pulsePrefab, firePoint.position, firePoint.rotation);
            isShooting = true;
            animator.SetBool("IsShooting", true);
            fire = false;
        }
        //Supergun Schuss
        if (superGun)
        {
            Instantiate(superGunPrefab, firePoint.position, firePoint.rotation);
            isShooting = true;
            animator.SetBool("IsShooting", true);
            fire = false;
        }
    }

    //Verzögerung und Animation
    void AllowShot () 
    {
        isShooting = false;
        animator.SetBool("IsShooting", false);
    }

    //Pulse zurück setzten
    void ResetPulse()
    {
        pulse = false;
        delay *= 2;
        pickUpUI.SetSliderPulse(0);
    }
}
