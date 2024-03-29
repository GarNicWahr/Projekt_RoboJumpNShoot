using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    public float delay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //Mit Delay zerst�ren
        Invoke("DestroyEffect", delay);
    }

    void DestroyEffect () 
    {
        Destroy(gameObject);
    }
}
