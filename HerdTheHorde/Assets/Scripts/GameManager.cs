using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int penTotal;
    public int finishedPens;
    public GameObject guiPanel;
    public GameObject successPanel;

    void Update()
    {
        if (penTotal == finishedPens)
        {
            //SceneManager.LoadScene(0, LoadSceneMode.Single);
            Time.timeScale = 0;
            guiPanel.gameObject.SetActive(false);
            successPanel.gameObject.SetActive(true);
        }
    }

    public void LevelComplete(int fPens)
    {
        finishedPens += fPens;
    }
}
