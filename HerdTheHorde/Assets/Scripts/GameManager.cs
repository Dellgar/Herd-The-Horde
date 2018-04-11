using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int penTotal;
    public int finishedPens;
    public GameObject guiPanel;
    public GameObject successPanel;
    public Text sheepLostText;

    public int deadSheeps;

    void Update()
    {

        if (Time.timeScale == 0) Cursor.visible = true;

        sheepLostText.text = "Sheep Lost: " + deadSheeps.ToString();
        if (penTotal == finishedPens)
        {
            Time.timeScale = 0;
            guiPanel.gameObject.SetActive(false);
            successPanel.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void LevelComplete(int fPens)
    {
        finishedPens += fPens;
    }

    public void SheepLost(int amountOfDeaths)
    {
        deadSheeps += amountOfDeaths;
    }
}
