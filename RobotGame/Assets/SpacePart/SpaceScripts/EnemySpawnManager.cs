using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject Player;

    public float yRange = 4;

    public float xRange;

    //Wann Spawned der erste Enemy
    public float startDelay = 4;

    //Zeitlichen Abstände in denen Enemys spawnen
    public float spawnInterval = 1.5f;

   

    // Start is called before the first frame update
    void Start ()
    {
        //Zum Spielstart zeitversetztes spawnen der Gegner, in einem bestimmten Intervall 
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    private void Update()
    {
        //Spawnabstand der Gegner zum Player
        xRange = Player.transform.position.x + 15;
    }

    void SpawnEnemy()
    {
        //Zufällige Anzahl und Position der gespawnten Gegner
        int randomIndex = Random.Range(0, 10);
        float randomYPosition = Random.Range(-yRange, yRange);
        Instantiate(Enemy, new Vector3(xRange, randomYPosition,0),Quaternion.identity);

            
    }
}
