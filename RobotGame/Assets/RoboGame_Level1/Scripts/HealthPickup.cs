using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject Feedback;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Heilung einsammeln
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(Feedback, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
