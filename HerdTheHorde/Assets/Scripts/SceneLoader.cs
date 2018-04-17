using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

    // Use this for initialization
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Replay()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	
	
}
