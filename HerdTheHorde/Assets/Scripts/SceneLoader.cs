using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
	private LevelManager lvlmgrScript;
	private PlayerProgress pprogScript;

	private void Start()
	{
		Scene scene = SceneManager.GetActiveScene();

		if ( scene.name == "Overworld")
		{
			lvlmgrScript = GameObject.Find("OverworldManager").GetComponent<LevelManager>();
		}

		if(GameObject.Find("_player") != null)
		{
			pprogScript = GameObject.Find("_player").GetComponent<PlayerProgress>();
		}

	}


    public void BackFromCredits()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        
		pprogScript.playerCurrency = 0;
		pprogScript.playerScore = 0;
		pprogScript.levelProgress = 1;
		if (GameObject.Find("_player") != null) Destroy(GameObject.Find("_player"));

		SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Replay()
    {
		Scene myScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(myScene.name);
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }

    public void LoadOverworld()
    {
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
    }

	public void LoadOnSuccess()
	{
		pprogScript.levelProgress += 1;	
		SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
	}

	public void LoadLevelIndex()
	{
		SceneManager.LoadScene( (5+lvlmgrScript.levelProgression), LoadSceneMode.Single);
	}

	public void LoadTestLevel()
    {
        SceneManager.LoadScene("TestEnvironment", LoadSceneMode.Single);
    }

	public void Endless()
	{
		SceneManager.LoadScene("Endless", LoadSceneMode.Single);
	}

	public void Credits()
	{
		SceneManager.LoadScene("Credits", LoadSceneMode.Single);
	}
    public void LoadLevel1()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(7, LoadSceneMode.Single);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(8, LoadSceneMode.Single);
	}
	public void LoadLevel4()
	{
		SceneManager.LoadScene(9, LoadSceneMode.Single);
	}









}
