using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseDialog;

    private bool isPaused = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //PauseMen� beim Start deaktiviert
        pauseDialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //PauseMen� abrufbar �ber Escape
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            PauseGame(!isPaused);        
        }
    }


    public void PauseGame(bool doPause)
    {
        //Abruf PauseMen�
        isPaused = doPause;
        pauseDialog.SetActive(isPaused);

        //Pausierung des Spiels und der Musik
        if (isPaused )
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
        }

        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
        

    }

    

    


}
