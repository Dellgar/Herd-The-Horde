using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

	private PlayerProgress pprogScript;


    private void Start()
	{
		//Scene scene = SceneManager.GetActiveScene();

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

		SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
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

	public void UnloadOptions()
	{
		SceneManager.UnloadSceneAsync("Options");
	}

	public void UnloadGallery()
	{
		SceneManager.UnloadSceneAsync("Gallery");
	}

	public void UnloadCredits()
	{
		SceneManager.UnloadSceneAsync("Credits");
	}

	public void LoadIntro()
    {
		Invoke("LoadIntroScene", 1f);
    }

	IEnumerator LoadIntroScene()
	{
		//yield return new WaitForSeconds(1f);
		Debug.Log("fuu");
		SceneManager.LoadScene("Intro", LoadSceneMode.Single);
		Debug.Log("faa");

		yield return null;
	}

	public void LoadOverworld_AfterIntro()
	{
		SceneManager.LoadScene("Overworld", LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("Intro");


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
		SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
	}

    public void CreditsSingle()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }

    public void Gallery()
    {
        SceneManager.LoadScene("Gallery", LoadSceneMode.Additive);
    }
    public void TitleMenu()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level_01", LoadSceneMode.Single);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level_02", LoadSceneMode.Single);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level_03", LoadSceneMode.Single);
	}
	public void LoadLevel4()
	{
		SceneManager.LoadScene("Level_04", LoadSceneMode.Single);
	}
    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level_05", LoadSceneMode.Single);
    }









}
