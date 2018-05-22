using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour {

	public int playerScore;
	public int playerCurrency;
	public int levelProgress;


	public void Awake()
	{
		DontDestroyOnLoad(this.gameObject);

		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	void Start ()
	{
		playerScore = 20000;
		playerCurrency = 0;
		levelProgress = 1;
	}
	

}
