using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    //Schussgeschwindigkeit
    public float shotSpeed = 50;

    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Schussrichtung nach links und Frameunabhängig
        transform.Translate(Vector2.left * Time.deltaTime * shotSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Abruf ImpactEffekt und Zerstörung des Schusses
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
