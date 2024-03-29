using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactDestroy : MonoBehaviour
{
    public float delay = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Mit Delay Zerstören
        Invoke("DestroyImpact", delay);
    }

    // Update is called once per frame
    void DestroyImpact()
    {
        Destroy(gameObject);
    }
}
