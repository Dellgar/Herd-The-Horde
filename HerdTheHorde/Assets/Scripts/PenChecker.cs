using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenChecker : MonoBehaviour {

    private TextMesh penText;
    private int sheepsInsidePen;

	// Use this for initialization
	void Awake () {
        penText = gameObject.GetComponentInChildren<TextMesh>();
	}
	
	// Update is called once per frame
	void UpdateScore () {
        penText.fontSize = 15;
        penText.text = "Sheeps: " + sheepsInsidePen;
	}

    public void CorrectPenForSheep(int sheepCount)
    {
        sheepsInsidePen += sheepCount;
        UpdateScore();
        return;
    }
}
