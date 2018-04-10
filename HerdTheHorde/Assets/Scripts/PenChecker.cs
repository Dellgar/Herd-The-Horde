using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenChecker : MonoBehaviour {

    private TextMesh penText;
    private int sheepsInsidePen;
    public int sheepGoal;
    [SerializeField] private bool isSheepGoalAchieved;
    public GameManager gManagerScript;

	void Awake ()
    {
        penText = gameObject.GetComponentInChildren<TextMesh>();
        gManagerScript = GameObject.Find("_manager").GetComponent<GameManager>();
	}

    private void Update()
    {
        UpdateScore();
        PenCompleted();
    }

    void UpdateScore ()
    {
        penText.fontSize = 15;
        penText.text = sheepsInsidePen + " / " + sheepGoal;
	}

    public void CorrectPenForSheep(int sheepCount)
    {
        sheepsInsidePen += sheepCount;
        UpdateScore();
    }

    void PenCompleted()
    {
        if (isSheepGoalAchieved)
            return;

        if (sheepsInsidePen >= sheepGoal)
        {
            Debug.Log("Pen finished");
            isSheepGoalAchieved = true;
            gManagerScript.LevelComplete(1);
        }
    }
}
