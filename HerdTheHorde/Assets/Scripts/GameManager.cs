using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public PlayerProgress pprogScript;

    public Camera levelCamera;
    public bool isEndless;
    public int gameState;                          // 1 Victory, 2 Game Over, 3 Ongoing
    public bool spawnerActive;
    public List<GameObject> deadSheepList;
    public Vector2[] sheepAllowedArea;

    //Game Handling
    public GameObject clickedSheep;
    public bool hasWolfSpawned;

    [Header("UserInterface")]
	public GameObject guiPanel;
	public GameObject successPanel;
	public GameObject gameoverPanel;
	public GameObject statisticsPanel;
	public GameObject pausePanel;


	public Text levelUI;
	public Text timeUI;
	public Text sheepUI;
    public Text scoreUI;

    [Header("Stat Objects")]
    public Text sheepLostText;
    public Text timeTakenText;
    public Text playerScoreText;

    [Header("Statistics")]
    public int penTotal;
    [SerializeField] private int finishedPens;
	[SerializeField] private int deadSheepAmount;
    public int permittedDeaths;
	[SerializeField] private float timeTakenInLvl;
    public int sheepToSpawn;
	public int sheepSpawned;
	[SerializeField] private int whiteSpawns;
	[SerializeField] private int blackSpawns;
    [SerializeField] private int playerScorePoints;




	private void Awake()
	{
		pprogScript = GameObject.Find("_player").GetComponent<PlayerProgress>();

		if (levelCamera == null ) levelCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

        if (SceneManager.GetActiveScene().name == "Endless")
		{
			isEndless = true;
		}
		else
		{
			isEndless = false;
		}
	}

	private void Start()
    {
        hasWolfSpawned = false;

        if (penTotal == 0) Debug.Log("penTotal not set for this level in _gamemanager");
        if (permittedDeaths == 0)
        {
            Debug.Log("permittedDeaths is set to 1 instead of 0");
            Debug.Log("check gameobject called _manager");
            permittedDeaths = 1;
        }

		levelUI.text = "World 1 : " + SceneManager.GetActiveScene().name;
        SetGameState(3);
    }

    private void OnDrawGizmos()
    {

        Vector3 posA = levelCamera.ViewportToWorldPoint(new Vector3(sheepAllowedArea[0].x, sheepAllowedArea[0].y, 5));  //upperleft
        Vector3 posB = levelCamera.ViewportToWorldPoint(new Vector3(sheepAllowedArea[1].x, sheepAllowedArea[1].y, 5));  //upperright
        Vector3 posC = levelCamera.ViewportToWorldPoint(new Vector3(sheepAllowedArea[2].x, sheepAllowedArea[2].y, 5));  //bottomleft
        Vector3 posD = levelCamera.ViewportToWorldPoint(new Vector3(sheepAllowedArea[3].x, sheepAllowedArea[3].y, 5));  //bottomright

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(posA, posB);
        Gizmos.DrawCube(posA, new Vector3(1f, 1f, 1f));
        Gizmos.DrawCube(posB, new Vector3(1f, 1f, 1f));

        //helpers to draw the rectangle for allowed area :: A D C B
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(posA, posD);
        Gizmos.DrawLine(posA, posC);
        Gizmos.DrawLine(posB, posD);
        Gizmos.DrawLine(posB, posC);

    }

    void Update()
    {

		if (pprogScript == null) pprogScript = GameObject.Find("_player").GetComponent<PlayerProgress>();

		//Statistics panel
		timeTakenInLvl = Time.timeSinceLevelLoad;
		sheepLostText.text = "Sheep Lost: " + deadSheepAmount.ToString();
		timeTakenText.text = "Time: " + timeTakenInLvl.ToString("F2");
		playerScoreText.text = "Score: " + pprogScript.playerScore.ToString();

		//UserInterface
		timeUI.text = timeTakenText.text;
		sheepUI.text = "Deaths: " + deadSheepAmount.ToString() + " / " + permittedDeaths.ToString();
		scoreUI.text = "Score: " + pprogScript.playerScore.ToString();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SetGameState(4);
		}
		

    }

	public void CleanRiplist()
	{
		if (deadSheepList.Contains(null))
		{
			deadSheepList.RemoveAll(GameObject => GameObject == null);
		}
	}


    public void SheepOnCursor(GameObject cursorSheep)
    {
        clickedSheep = cursorSheep;
    }

    public void PlayerScore(int scoreAmount)
    {
        pprogScript.playerScore += scoreAmount;
    }

    public void LevelComplete(int fPens)
    {
        finishedPens += fPens;

        if (finishedPens >= penTotal) SetGameState(1);
    }

    public void SheepRipList(string sheepStatus, GameObject sheepObject)
    {
		if(sheepStatus == "timeup" || sheepStatus == "unsaved") deadSheepList.Add(sheepObject);
		if(sheepStatus == "dead" || sheepStatus == "saved") deadSheepList.Remove(sheepObject);
	}

    public void SheepLost(int amountOfDeaths)
    {
        deadSheepAmount += amountOfDeaths;

        if (deadSheepAmount >= permittedDeaths) SetGameState(2);
    }

    public void SheepSpawn (int spawned, string race)
    {
        sheepSpawned += spawned;
        switch (race)
        {
            case "white":
                whiteSpawns++;
                break;

            case "black":
                blackSpawns++;
                break;
        }

        if (sheepToSpawn == sheepSpawned)
        {
            spawnerActive = false;
        }
    }

    public void SetGameState(int result)
    {
        switch (result)
        {
            case 1: //Victory
                gameState = result;
                Time.timeScale = 0;

                guiPanel.gameObject.SetActive(false);
                successPanel.gameObject.SetActive(true);
                statisticsPanel.gameObject.SetActive(true);

				if (Cursor.visible == false) Cursor.visible = true;
                break;

            case 2: //Game Over
                gameState = result;
                Time.timeScale = 0;

                guiPanel.gameObject.SetActive(false);
                gameoverPanel.gameObject.SetActive(true);
                statisticsPanel.gameObject.SetActive(true);

				if (Cursor.visible == false) Cursor.visible = true;
                break;

            case 3: //In Progress
                gameState = result;
                Time.timeScale = 1;

                guiPanel.gameObject.SetActive(true);
                successPanel.gameObject.SetActive(false);
                gameoverPanel.gameObject.SetActive(false);
                statisticsPanel.gameObject.SetActive(false);

				if (Cursor.visible == true) Cursor.visible = false;
                break;

            case 4: //Paused

				//Pause ON
				if (Time.timeScale == 1f)
				{
					AudioListener.pause = true;
					Time.timeScale = 0f;
					gameState = 4;
					pausePanel.gameObject.SetActive(true);
					if (Cursor.visible == false) Cursor.visible = true;
				}

				//Pause OFF
				else if (Time.timeScale == 0f)
				{
					AudioListener.pause = false;
					Time.timeScale = 1f;
					gameState = 3;
					pausePanel.gameObject.SetActive(false);
					if (Cursor.visible == true) Cursor.visible = false;
				}

				guiPanel.gameObject.SetActive(true);
                statisticsPanel.gameObject.SetActive(false);

                break;
        }
    }

}
