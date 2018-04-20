using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenChecker : MonoBehaviour {

    private TextMesh penText;
    private int sheepsInsidePen;
    public int sheepGoal;
    [SerializeField] private bool isSheepGoalAchieved;
    public GameManager gmScript;

	void Awake ()
    {
        penText = gameObject.GetComponentInChildren<TextMesh>();
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
	}

    private void Update()
    {
        UpdateScore();
        PenCompleted();
    }

    void UpdateScore ()
    {
		if (gmScript.isEndless) penText.text = sheepsInsidePen.ToString();
		else penText.text = sheepsInsidePen + " / " + sheepGoal;
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
            gmScript.LevelComplete(1);
        }
    }
}
