using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Projektil bewegen
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
       

        //Projektil drehen
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Update()
    {
        //Projektil bewegen
        transform.position += speed * Time.deltaTime * (Vector3)direction.normalized;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        //Impact Effect
        Instantiate(impactEffect, transform.position, transform.rotation);

        //Fliegender Gegner
        EnemyAir enemyAir = collision.GetComponent<EnemyAir>();
        if (enemyAir != null)
        {
            enemyAir.TakeDamage(damage);
        }

        //Skelett
        EnemyControler enemy = collision.GetComponent<EnemyControler>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        //Lizard
        Enemy_Lizard enemyL = collision.GetComponent<Enemy_Lizard>();
        if (enemyL != null)
        {
            enemyL.TakeDamage(damage);
        }

        //Boss
        BossController enemyB = collision.GetComponent<BossController>();
        if (enemyB != null)
        {
            enemyB.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
