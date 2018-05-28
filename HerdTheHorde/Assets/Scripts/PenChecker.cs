using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenChecker : MonoBehaviour {
	private GameManager gmScript;
	private Sheep sheepScript;
    private AudioSource audioSource;
    public AudioClip correctPenAudio;

	private TextMesh penText;
    private int sheepsInsidePen;
    public int sheepGoal;
    [SerializeField] private bool isSheepGoalAchieved;
	private int sheepsScoreValue;


	void Awake ()
    {
		gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
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

		if(isSheepGoalAchieved) penText.text = "Completed";
	}

    public void CorrectPenForSheep(int sheepCount)
    {
        audioSource.PlayOneShot(correctPenAudio);
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
			if (gmScript.isEndless)
			{
				Debug.Log("Endless Mode: On");
			}
			else
			{
				Debug.Log("Pen finished");
				isSheepGoalAchieved = true;
				gmScript.LevelComplete(1);
			}
		}
    }
}
