using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Rigidbody2D rbComponent;
    public int health = 500;
    public GameObject deathEffect;
    public GameObject itemDrop;
    public Transform playerPosition;
    public HealthBarEnemy healthBar;
    public float moveSpeed = 2f;
    public int moveDirection = -1;
    public float moveDirectionf;
    public float startTime = 1f;
    public float repeatRate = 1f;
    private bool facingRight = false;
    private bool isVisible=false;


    // Start is called before the first frame update
    void Start()
    {
        rbComponent = GetComponent<Rigidbody2D>();
        InvokeRepeating("PlayerPositionController", startTime, repeatRate);
        healthBar.SetHealth(health);
    }


    void FixedUpdate()
    {
        if (isVisible)
        {
            //Gegner bewegen
            rbComponent.velocity = new Vector2(moveDirection * moveSpeed * Time.fixedDeltaTime, rbComponent.velocity.y);

            if (moveDirection != 0)
            {
                if((moveDirection == 1 && !facingRight) ||(moveDirection == -1 && facingRight))
                {
                    Flip();
                }
            }
        }    
    }

    //Wo ist der Spieler?
    void PlayerPositionController()
    {
        playerPosition = GameObject.FindGameObjectWithTag("PlayerRig").transform;
        Vector2 bossDirection = new Vector2(playerPosition.transform.position.x - gameObject.transform.position.x, 0f);

        moveDirectionf = bossDirection.x;
        if (moveDirectionf < 0f)
        {
            moveDirection = -1;
           
        }
        else if (moveDirectionf > 1f)
        {
            moveDirection = 1;
         
        }
        else if (moveDirectionf == 0f)
        {
            moveDirection = 0;
        }
    }

    //Schaden nehmen
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    //Blickrichtung ändern
    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    //Gegner zerstören
    void DestroyEnemy()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(itemDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    //Umdrehen
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {

            Flip();
            moveDirection = -moveDirection;
        }

    }
    //ist der Boss sichtbar
    void OnBecameVisible()
    {
        isVisible = true;
    }
}
