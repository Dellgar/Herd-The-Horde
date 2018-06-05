using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFunc : MonoBehaviour {

	public GameObject titlePanel;
	public GameObject titleLogo;

	public void ShowTitlePanel()
	{
		titleLogo.SetActive(false);
		titlePanel.SetActive(true);
	}
}
