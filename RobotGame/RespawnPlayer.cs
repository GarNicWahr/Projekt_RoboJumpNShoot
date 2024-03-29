using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public GameObject player;
    
    
    public void RespawnCharacter()
    {
        
            Instantiate(player, transform.position, Quaternion.identity);
        
            Destroy(gameObject);
        
    }

   
}
