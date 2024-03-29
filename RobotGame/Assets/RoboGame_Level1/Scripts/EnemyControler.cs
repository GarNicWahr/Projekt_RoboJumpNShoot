using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rbComponent;
    public int health = 100;
    public GameObject deathEffect;
    public HealthBarEnemy healthBar;
    public float moveSpeed = 2f;
    public int moveDirection = 1;
    private bool facingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rbComponent = GetComponent<Rigidbody2D>();
        healthBar.SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
       //Laufen Animation
        if (Mathf.Abs(moveDirection) > 0f)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveDirection));
        }
    }

    void FixedUpdate()
    {
        //Gegner bewegen
        rbComponent.velocity = new Vector2( moveDirection * moveSpeed * Time.fixedDeltaTime, rbComponent.velocity.y);
    }

    //Schaden nehmen
    public void TakeDamage (int damage) 
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            DestroyEnemy ();
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
        Destroy(gameObject);
    }
    //Umdrehen
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Umdrehen bei Collision mit Wand
        if (collision.gameObject.CompareTag("Walls"))
        {
           
            Flip();
            moveDirection = -moveDirection;
        }
        
    }
}
