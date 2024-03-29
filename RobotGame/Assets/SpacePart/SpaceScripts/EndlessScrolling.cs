using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScrolling : MonoBehaviour
{

    public float scrollSpeed = 2;
    private Transform[] backgrounds;

    private float backgroundWidth;

 
    // Start is called before the first frame update
    void Start()
    {
        backgrounds = GetComponentsInChildren<Transform>(); 

        backgroundWidth= backgrounds[1].position.x - backgrounds[0].position.x;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var background in backgrounds)
        {
            background.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

            if(background.position.x > -backgroundWidth)
            {
                background.position = new Vector2(background.position.x + backgroundWidth * backgrounds.Length, background.position.y);
            }
        }
    }
}
