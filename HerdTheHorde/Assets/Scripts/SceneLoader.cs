using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Replay()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }

    public void LoadOverworld()
    {
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

	public void Endless()
	{
		SceneManager.LoadScene("Endless", LoadSceneMode.Single);
	}





  
	
	
}
