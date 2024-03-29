using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Zugriff auf den SzenenManager
using UnityEngine.SceneManagement;

public class MenueController : MonoBehaviour
{
    public float delay = 0.3f;


    public void QuitGame()
    {
        //Beendet die Anwendung
        Application.Quit();
    }

    public void StartGame()
    {
        //Startet die n�chste Szene mit einer Verz�gerung
        Invoke("LoadStartGameScene", delay);
    }

    public void RestartGame()
    {
        //Startet das Game wieder im Dungeon mit einer Verz�gerung
        Invoke("LoadRestartGame", delay);
    }

    public void MainMenue()
    {
        //Ruft das Hauptmen� auf mit einer Verz�gerung
        Invoke("LoadMainMenueScene", delay);
    }


    public void LoadStartGameScene()
    {
        //Startet die n�chste Szene
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadRestartGame()
    {
        //Startet das Game wieder im Dungeon
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void MLoadMainMenueScene()
    {
        //Ruft das Hauptmen� auf
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}
