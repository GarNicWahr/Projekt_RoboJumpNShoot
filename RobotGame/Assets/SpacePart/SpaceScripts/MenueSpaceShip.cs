using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueSpaceShip : MonoBehaviour
{
    //Bewegungsgeschwindigkeit
    public float speed;

    //Bezug zur Animation
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("IsMoving", 1f);

       
    }

    // Update is called once per frame
    void Update()
    {
        //Automatische Vorwärtsbewegung
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
