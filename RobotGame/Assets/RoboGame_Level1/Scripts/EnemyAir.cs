using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAir : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public HealthBarEnemy healthBar;

    void Start()
    {
        healthBar.SetHealth(health);
    }

    //Gegner Schaden zufügen
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    //Gegner zerstören
    void DestroyEnemy()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
