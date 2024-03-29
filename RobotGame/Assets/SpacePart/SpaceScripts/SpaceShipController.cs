using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipController : MonoBehaviour
{
    //Bewegungsgeschwindigkeit
    public float speed;

    //Bezug zur Animation
    public Animator animator;

    //Begrenzung zum Bildschirmrand
    public float yRange = 4.5f;

    //Leben
    public int maxHealth = 100;
    public int currentHealth;

    //Schaden
    public int damage = 50;

    public GameObject deathEffect;

    //Bezug zur Lebensanzeige
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("IsMoving", Mathf.Abs(verticalInput));

        //Automatische Vorwärtsbewegung
        //transform.Translate(Vector2.right * Time.deltaTime * speed);

        //Lenkung Oben/Unten per Tastendruck
        transform.Translate(Vector2.up * Time.deltaTime * speed * verticalInput);

        //Begrenzung zum oberen und unteren Bildschirmrand
        float clampedY = Mathf.Clamp(transform.position.y, -yRange, yRange);
        transform.position = new Vector2(transform.position.x, clampedY);

        if(currentHealth <= 0)
        {
            //Abruf DeathEffect
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Zerstörung des GameObjects
            Destroy(gameObject);

            SceneManager.LoadScene(3);

        }


        //Rotation Oben/Unten per Tastendruck 
        //transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * verticalInput);


        //Begrenzung zum unteren Bildschirmrand
        /*if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }*/

        //Begrenzung zum oberen Bildschirmrand
        /* if (transform.position.y > yRange)
         {
             transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
         }*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

}
