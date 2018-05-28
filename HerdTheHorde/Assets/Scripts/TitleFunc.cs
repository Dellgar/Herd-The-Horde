using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFunc : MonoBehaviour {

	public GameObject titlePanel;
	public GameObject titleLogo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowTitlePanel()
	{
		titleLogo.SetActive(false);
		titlePanel.SetActive(true);
	}
}
