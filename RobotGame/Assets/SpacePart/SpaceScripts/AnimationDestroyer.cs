using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDestroyer : MonoBehaviour
{
    public float delay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyEffect", delay);
    }

    void DestroyEffect()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
