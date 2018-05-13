using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenChecker : MonoBehaviour {
	private GameManager gmScript;
	private Sheep sheepScript;

	private TextMesh penText;
    private int sheepsInsidePen;
    public int sheepGoal;
    [SerializeField] private bool isSheepGoalAchieved;
	private int sheepsScoreValue;


	void Awake ()
    {
		gmScript = GameObject.Find("_manager").GetComponent<GameManager>();

		penText = gameObject.GetComponentInChildren<TextMesh>();
	}

	private void Start()
	{
		
		//sheepScript = GetComponent<Sheep>();
	}

	private void Update()
    {
        UpdatePenStatus();
        PenCompleted();
    }

    void UpdatePenStatus ()
    {
		if (gmScript.isEndless) penText.text = sheepsInsidePen.ToString();
		else penText.text = sheepsInsidePen + " / " + sheepGoal;
	}

    public void CorrectPenForSheep(int sheepCount)
    {
		sheepScript = gmScript.clickedSheep.GetComponent<Sheep>();

		sheepsInsidePen += sheepCount;
        UpdatePenStatus();
        gmScript.PlayerScore(sheepScript.scoreValue);
    }

    void PenCompleted()
    {
        if (isSheepGoalAchieved)
        {
            return;
        }

        if (sheepsInsidePen >= sheepGoal)
        {
            Debug.Log("Pen finished");
            isSheepGoalAchieved = true;
            gmScript.LevelComplete(1);
        }
    }
}
