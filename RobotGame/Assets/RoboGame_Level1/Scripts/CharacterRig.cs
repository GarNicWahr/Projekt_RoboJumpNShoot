using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRig : MonoBehaviour
{
  
    public Transform player;
    public float speed;
    public bool isGameOver=false;
   
    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            //Spieler in der Szene finden
            player = GameObject.FindGameObjectWithTag("Player").transform;

            //Spieler folgen
            transform.position = player.transform.position;
        }
        else
        {
            transform.position = transform.position;
        }
        

    }

    public void IsGameOver()
    {
        isGameOver = true;
    }
}
