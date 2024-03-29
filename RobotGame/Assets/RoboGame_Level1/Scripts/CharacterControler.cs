using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterControler : MonoBehaviour
{
    public CapsuleCollider2D ColiderComponent;
    public Rigidbody2D rbComponent;
   
    public Animator animator;
    public GameObject deathEffect;
    public HealthBar healthBar;
    public PickUpUI pickUpUI;
    public float jumpForce = 5f;
    public int maxJumps = 2;
    public bool isGrounded = false;
    public bool isOnIce = false;
    public float delayAnimation = 0.5f;
    public int health;
    public int hpPickup = 20;
    public int maxHealth = 100;
    public int spaceShipParts = 0;
    public int maxSpaceShipParts = 3;
    
    private bool isJumping = false;
    private float moveInput;
    private bool facingRight = true;
    private int jumpCount = 0;
    public float moveSpeed = 5f;
    private bool jump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //Inizieren von Componenten
        ColiderComponent = GetComponent<CapsuleCollider2D>();
        rbComponent = GetComponent<Rigidbody2D>();
        healthBar = FindObjectOfType<HealthBar>();
        pickUpUI = FindObjectOfType<PickUpUI>();

        //Leben bei Spawn auf 100% setzen
        health = maxHealth;
        healthBar.SetHealth(maxHealth);
    
    }

    void Update()
    {
        //Sprung
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
      
        }
    
        //Bewegung
        moveInput = Input.GetAxis("Horizontal");
       

        //Blickrichtung
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0f && facingRight)
        {
            Flip();
        }

        //Animation Laufen
        if (isGrounded || isOnIce)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }
        else
        {
            animator.SetFloat("Speed",0);
        
        }

        //Animation Sprung
        if (isJumping) 
        {
            animator.SetBool("IsJumping", true); 
            
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        
    }

    void FixedUpdate()
    {
        //Spieler bewegen auf Eis

        if (isOnIce)
        {
            rbComponent.AddForce(new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime , rbComponent.velocity.y));
        }


        //Spieler bewegen auf Boden
       else
        {
            rbComponent.velocity = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, rbComponent.velocity.y);
        }

        //Springen
        if (jump)
        {
            Jump();
            jump = false;
        }

    }


    //Sprungmechanik
    void Jump()
    {
        if (jumpCount < maxJumps)
        {
            Rigidbody2D ridigbodyComponente = GetComponent<Rigidbody2D>();
            rbComponent.velocity = new Vector2(rbComponent.velocity.x, 0f);
            rbComponent.AddForce(new Vector2(0f, jumpForce) * Time.fixedDeltaTime, ForceMode2D.Impulse);
            jumpCount++;
            isJumping = true;
            isGrounded = false;
            isOnIce = false;
        }
    }

    //Blickrichtung ändern
    void Flip () 
    {
        facingRight = !facingRight;

        transform.Rotate(0f,180f,0f);
    }

    //Schaden nehmen
    public void PlayerTakeDamage (int damage) 
    {
        health -= damage;

        healthBar.SetHealth(health);

        if (health <= 0)
        {
            DestroyPlayer();
        }
    }

    //Sterben
    void DestroyPlayer()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        GameObject spawnPointObject = GameObject.Find("MainSpawnPlayer");
        if (spawnPointObject != null )
        {
            SpawnPlayer spawnPlayer = spawnPointObject.GetComponent<SpawnPlayer>();
            if (spawnPlayer != null)
            {
                //Trigger Respawn
                spawnPlayer.RespawnCharacter();
            }
        }

        Destroy(gameObject);
    }

    public int GetHealth () 
    {    
        return health; 
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {   //Deathzone
        if (collision.gameObject.CompareTag("DeathZone")) 
        {
            PlayerTakeDamage(100);
        }
        //HP pickup
        if (collision.gameObject.CompareTag("HealthPickup"))
        {
            health += hpPickup;
            if (health > maxHealth) 
            {
            health = maxHealth;
            }
            healthBar.SetHealth(health);
        }
        //SpaceShipPart pickup
        if (collision.gameObject.CompareTag("SpaceShipPart"))
        {
            pickUpUI.SetSliderSpacePart(1);
            spaceShipParts++;
            GameObject spawnPointObject = GameObject.Find("MainSpawnPlayer");
            SpawnPlayer spawnPlayer = spawnPointObject.GetComponent<SpawnPlayer>();
            spawnPlayer.SpaceShipParts();
        }
    }

    //Sprunganzahl zurück setzen
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boden") || collision.gameObject.CompareTag("Eis"))
        {
            jumpCount = 0;
           
            
        }

        //Eis abfragen
        if(collision.gameObject.CompareTag("Eis"))
        {
            isOnIce = true;
            isJumping= false;
            isGrounded = false;
        }

        //Boden abfragen
        if(collision.gameObject.CompareTag("Boden"))
        {
            isGrounded = true;
            isOnIce = false;
            isJumping = false;
        }
        
        //Getroffen werden Gegner
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerTakeDamage(20);
        }

        //Getroffen werden Lizard
        if (collision.gameObject.CompareTag("Lizard"))
        {
            PlayerTakeDamage(30);
        }

        //Getroffen werden Fliegender Gegner
        if (collision.gameObject.CompareTag("EnemyAir"))
        {
            PlayerTakeDamage(20);
        }

        //Getroffen werden Gegner Geist
        if (collision.gameObject.CompareTag("EnemyGhost"))
        {
            PlayerTakeDamage(30);
        }

        //Getroffen werden Boss
        if (collision.gameObject.CompareTag("Boss"))
        {
            PlayerTakeDamage(50);
        }
    }
}
