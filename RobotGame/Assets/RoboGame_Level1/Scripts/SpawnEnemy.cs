using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject goEnemy;
    private bool hasSpawned = false;


    void OnBecameVisible()
    {
        //Spawn Enemy
        if (!hasSpawned)
        {
            Instantiate(goEnemy, transform.position, Quaternion.identity);

            hasSpawned = true;
        }  
    }
}
