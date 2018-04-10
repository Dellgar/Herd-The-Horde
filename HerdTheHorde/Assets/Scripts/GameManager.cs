using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int penTotal;
    public int finishedPens;

    void Update()
    {
        if (penTotal == finishedPens)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    public void LevelComplete(int fPens)
    {
        finishedPens += fPens;
    }
}
