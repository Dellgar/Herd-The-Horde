using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	private PlayerProgress pprogScript;
	public int levelProgression;

	public GameObject[] levelsButtons;

	public Sprite locked;
	public Sprite unlocked;


	private void Awake()
	{
		pprogScript = GameObject.Find("_player").GetComponent<PlayerProgress>();
	}

	// Update is called once per frame
	void Update ()
	{

		if (pprogScript == null) pprogScript = GameObject.Find("_player").GetComponent<PlayerProgress>();

		levelProgression = pprogScript.levelProgress;

		for (int i = 0; i < levelsButtons.Length; i++)
		{
			if (i + 1 > pprogScript.levelProgress)
			{
				levelsButtons[i].GetComponent<Button>().interactable = false;
				levelsButtons[i].GetComponent<Image>().sprite = locked;
			}
			else
			{
				levelsButtons[i].GetComponent<Button>().interactable = true;
				levelsButtons[i].GetComponent<Image>().sprite = unlocked;

			}
		}

	}
}
