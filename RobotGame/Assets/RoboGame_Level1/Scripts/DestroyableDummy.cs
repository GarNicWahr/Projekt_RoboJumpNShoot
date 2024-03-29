using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableDummy : MonoBehaviour
{
    public GameObject feedback;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {   //objekt zerstören und feedback spawnen
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(feedback, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
