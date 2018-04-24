﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public bool isEndless;
    public int gameState;                          // 1 Victory, 2 Game Over, 3 Ongoing
    public bool spawnerActive;
    public List<GameObject> deadSheepList;

	[Header("UserInterface")]
	public GameObject guiPanel;
	public GameObject successPanel;
	public GameObject gameoverPanel;
	public GameObject statisticsPanel;

	public Text levelUI;
	public Text timeUI;
	public Text sheepUI;
    public Text scoreUI;

    [Header("Stat Objects")]
    public Text sheepLostText;
    public Text timeTakenText;

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

    void Update()
    {
        timeTakenInLvl = Time.timeSinceLevelLoad;
        sheepLostText.text = "Sheep Lost: " + deadSheepAmount.ToString();
        timeTakenText.text = "Time: " + timeTakenInLvl.ToString("F2");
		timeUI.text = timeTakenText.text;
		sheepUI.text = "Deaths: " + deadSheepAmount.ToString() + " / " + permittedDeaths.ToString();
        scoreUI.text = "Score: " + playerScorePoints.ToString();

        if(Input.GetKey(KeyCode.Escape))
        {
            SetGameState(4);
        }

    }

    public void PlayerScore(int scoreAmount)
    {
        playerScorePoints += scoreAmount + Mathf.RoundToInt(timeTakenInLvl);
    }

    public void LevelComplete(int fPens)
    {
        finishedPens += fPens;

        if (finishedPens >= penTotal) SetGameState(1);
    }

    public void SheepRipList(string sheepStatus, GameObject sheepObject)
    {
		if(sheepStatus == "timeup") deadSheepList.Add(sheepObject);
		if(sheepStatus == "dead") deadSheepList.Remove(sheepObject);
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

                if (Time.timeScale == 1f) Time.timeScale = 0f;
                else Time.timeScale = 1f;

                guiPanel.gameObject.SetActive(true);
                statisticsPanel.gameObject.SetActive(false);
                if (Cursor.visible == true) Cursor.visible = false;
                break;
        }
    }

}
