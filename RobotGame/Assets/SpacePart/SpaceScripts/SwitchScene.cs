using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //L�d die n�chste Szene 
        SceneManager.LoadScene(2);
    }
}
