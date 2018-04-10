using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenChecker : MonoBehaviour {

    private TextMesh penText;
    private int sheepsInsidePen;

	void Awake ()
    {
        penText = gameObject.GetComponentInChildren<TextMesh>();
	}

    private void Update()
    {
        UpdateScore();
    }

    void UpdateScore ()
    {
        penText.fontSize = 15;
        penText.text = " " + sheepsInsidePen;
	}

    public void CorrectPenForSheep(int sheepCount)
    {
        sheepsInsidePen += sheepCount;
        UpdateScore();
    }
}
