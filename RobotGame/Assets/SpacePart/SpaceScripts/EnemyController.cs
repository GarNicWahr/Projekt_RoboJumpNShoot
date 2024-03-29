using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Bewegungsgeschwindigkeit der Gegner
    public float movementSpeed = 5;

    

    // Update is called once per frame
    void Update()
    {
        //Bewegungsrichtung der Gegner
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("deathBox"))

        {
            Destroy(gameObject);
        }
        
    }

  

  

}
