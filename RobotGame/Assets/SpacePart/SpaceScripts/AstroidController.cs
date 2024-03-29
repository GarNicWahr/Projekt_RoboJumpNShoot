using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidController : MonoBehaviour
{
    //Bewegungsgeschwindigkeit der Asteroiden
    public float movementSpeed = 8;

    public float rotationSpeed = 20;

    public Rigidbody2D rB;




    // Update is called once per frame
    void Update()
    {
        //Bewegungsrichtung der Asteroiden
        //transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);

        rB.velocity = new Vector2 (movementSpeed * Time.deltaTime, rB.velocity.y);

        //Rotation 
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("deathBox"))

        {
            Destroy(gameObject);
        }
    }
}
