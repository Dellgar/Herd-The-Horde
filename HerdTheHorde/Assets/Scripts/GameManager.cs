using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public GameObject guiPanel;
    public GameObject successPanel;
    public GameObject gameoverPanel;
    public GameObject statisticsPanel;
    private int gameState;                          // 1 Victory, 2 Game Over, 3 Ongoing

    [Header("Stat Objects")]
    public Text sheepLostText;
    public Text timeTakenText;

    [Header("Statistics")]
    public int penTotal;
    public int finishedPens;
    public int deadSheepAmount;
    public int permittedDeaths;
    public float timeTakenInLvl;

    private void Start()
    {
        if (penTotal == 0) Debug.Log("penTotal not set for this level in _gamemanager");
        if (permittedDeaths == 0)
        {
            Debug.Log("permittedDeaths is set to 1 instead of 0");
            Debug.Log("check gameobject called _manager");
            permittedDeaths = 1;
        }

        SetGameState(3);
    }

    void Update()
    {
        timeTakenInLvl = Time.timeSinceLevelLoad;
        sheepLostText.text = "Sheep Lost: " + deadSheepAmount.ToString();
        timeTakenText.text = "Time: " + timeTakenInLvl.ToString("F2");
    }

    public void LevelComplete(int fPens)
    {
        finishedPens += fPens;

        if (finishedPens >= penTotal) SetGameState(1);
    }

    public void SheepLost(int amountOfDeaths)
    {
        deadSheepAmount += amountOfDeaths;

        if (deadSheepAmount >= permittedDeaths) SetGameState(2);
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
        }
    }
}
