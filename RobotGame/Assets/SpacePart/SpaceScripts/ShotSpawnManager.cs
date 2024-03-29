using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpawnManager : MonoBehaviour
{
    public GameObject Shot;
    public Transform ShotPos;
    //Ab wann werden die Schüsse abgesetzt
    public float startTime = 0;
    //In welchem Interval werden die Schüsse abgefeuert
    public float spawnInterval = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnShot", startTime, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }



    private void SpawnShot()
    {

        GameObject shotObject = Instantiate(Shot,ShotPos.position, Quaternion.identity);
        shotObject.transform.localScale = new Vector3(-3f, 3f, 3f);

    }

   /* void flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }*/

}
