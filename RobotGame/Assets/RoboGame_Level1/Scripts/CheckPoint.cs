using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CheckPoint : MonoBehaviour
{
    public GameObject MainSpawn;
    public GameObject spawnEffect;
    public Transform spawnPoint;
    public Light2D light2D;

    private SpawnPlayer spawnPlayer;
    private bool isActive = false;

    void Start()
    {
        spawnPlayer = MainSpawn.GetComponent<SpawnPlayer>();
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Checkpoint Aktiv
        if (!isActive && collision.CompareTag("Player"))
        {
            Instantiate(spawnEffect,transform.position, Quaternion.identity);
            light2D.intensity = 1f;
            spawnPlayer.SetSpawnPoint(spawnPoint.position);
            isActive = true;
        }
    }
}
