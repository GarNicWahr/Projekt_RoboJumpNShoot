using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
  
    public GameObject spawnEffect;

    public GameObject gameOverDialog;

    public GameObject completedDialog;

    public CharacterRig characterRig;

    public BossBullet bossBullet;

    public GhostBullet ghostBullet;

    public LivesUI livesUI;

    public GameManager gameManager;

    public int playerLives = 3;

    public float respawnDelay = 1f;

    private int spaceShipParts = 0;

    private Vector3 respawnPoint;

    private bool checkPoint = false ;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
        livesUI = FindAnyObjectByType<LivesUI>();
        gameOverDialog.SetActive(false);
        completedDialog.SetActive(false);
        //Spieler Spawnen
        SpawnerPlayer();

    }
    //Spieler Leben reduzieren
   public int PlayerLiveCounter() 
   {
        playerLives--;
        return playerLives; 
   }

    //SpaceShipParts hochzählen und Level Completed anzeigen
    public void SpaceShipParts()
    {
        spaceShipParts++;
        completedDialog.SetActive(true);
        gameManager.PauseGame(true);
    }
    //Checkpoint Spawnpunkt setzen
    public void SetSpawnPoint(Vector3 point)
    {
        respawnPoint = point;
        checkPoint = true ;
    }

    public void RespawnCharacter()
    {
        //Respawn vor 1tem Checkpoint
        if (!checkPoint)
        {
            SpawnerPlayer();
        }
    
        //Respawn Checkpoint
        if (checkPoint && playerLives > 0)
        {
            SpawnerPlayer();
            PlayerLiveCounter();
            livesUI.SetLiveCount(0);
        }

        else if (playerLives == 0)
        {
            characterRig.IsGameOver();
            ghostBullet.IsGameOver();
            bossBullet.IsGameOver();
            gameOverDialog.SetActive (true);
        }
    }
    //Spieler Spawnen
    void SpawnerPlayer()
    {
        Instantiate(playerPrefab, respawnPoint, Quaternion.identity);
        Instantiate(spawnEffect, respawnPoint, Quaternion.identity);
    }
}
