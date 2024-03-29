using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Geschwindigkeit der Verschiebung des Hintergrunds
    public float speed = 10;
    //Startposition speichern
    //private Vector3 startPosition;
     //Festlegung der Breite ab der die Wiederholung einsetzt
    private float repeatWidth;
    //Bezug zum BoxCollider der Hintergründe
    public BoxCollider2D Box;

    //private Transform[] backgrounds;

    // Start is called before the first frame update
    void Start()
    {
   

        //backgrounds = GetComponentsInChildren<Transform>();

        //repeatWidth = backgrounds[1].position.x *2 - backgrounds[0].position.x;

        //Festlegung der Startposition
        //startPosition = transform.position;
        //Zugriff auf den BoxColliders des Hintergrunds und Größenabfrage der Breite (x), welcher durch die Hälfte der Breite geteilt wird. Erzeugt den endlosen Scrolling-Effekt
        repeatWidth = Box.size.x /2;
    }

    // Update is called once per frame
    void Update()
    {
        //Verschiebund des Hintergrunds nach links
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //Wenn die Verschiebung des Hintergrunds die Hälfte der Hintergrundbreite erreicht hat, wird dieser wieder zurückgesetzt
        if (transform.position.x < -repeatWidth)
        {
            transform.position = new Vector3(transform.position.x + repeatWidth, transform.position.y, transform.position.z);
        }

    }
}
