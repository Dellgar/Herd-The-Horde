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

	private void Start()
	{
		Debug.Log("start in lvl select");
		StartCoroutine("UnlockingLevels", 0.6f);
	}

	IEnumerator UnlockingLevels()
	{
		if (pprogScript == null) pprogScript = GameObject.Find("_player").GetComponent<PlayerProgress>();

		levelProgression = pprogScript.levelProgress;

		for (int i = 0; i < levelsButtons.Length; i++)
		{
			if (i+1> pprogScript.levelProgress)
			{
				levelsButtons[i].GetComponent<Button>().interactable = false;
				levelsButtons[i].transform.GetChild(0).gameObject.SetActive(true);
				//levelsButtons[i].GetComponent<Image>().sprite = locked;
			}
			else
			{
				levelsButtons[i].transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("unlocked", true);
				yield return new WaitForSeconds(0.6f);

				levelsButtons[i].GetComponent<Button>().interactable = true;

				
				levelsButtons[i].transform.GetChild(0).gameObject.SetActive(false);

			}
		}
		yield return null;
	}

}
