using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBullet : MonoBehaviour
{
    public GameObject impactEffect;
    public Rigidbody2D rbComponent;
    public Transform PlayerPosition;
    public int damage = 20;
    public float speed = 20f;

    private Vector2 bulletDirection;
    private bool isGameOver=false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isGameOver)
        {
            //Spieler finden
            PlayerPosition = GameObject.FindGameObjectWithTag("PlayerRig").transform;

            //Flugrichtung Projektil
            bulletDirection = (PlayerPosition.position - transform.position).normalized;
            rbComponent.velocity = bulletDirection.normalized * speed;

            //Projektil ausrichten
            float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            transform.localScale = new Vector3(1, 1, 1);
        }
        
    }



    void OnTriggerEnter2D(Collider2D collision)
    {


        //Spieler Schaden zufügen
        CharacterControler player = collision.GetComponent<CharacterControler>();
        if (player != null)
        {
            player.PlayerTakeDamage(damage);
        }

        if (collision.CompareTag("Player"))
        {
            //Spawn Impact Effect
            Instantiate(impactEffect, transform.position, transform.rotation);

            //Projektil zerstören
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boden"))
        {
            //Spawn Impact Effect
            Instantiate(impactEffect, transform.position, transform.rotation);

            //Projektil zerstören
            Destroy(gameObject);
        }

        if (collision.CompareTag("Walls"))
        {
            //Spawn Impact Effect
            Instantiate(impactEffect, transform.position, transform.rotation);

            //Projektil zerstören
            Destroy(gameObject);
        }
    }

    public void IsGameOver()
    {
        isGameOver = true;
    }
}
