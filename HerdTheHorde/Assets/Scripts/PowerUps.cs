using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    [Range(0,1)]
    public float timeBaahmbValue;
    public float timeBaahmbDuration;
    public float test;

	// Use this for initialization
	void Start ()
    {
        test = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeBaahmbDuration = Time.timeSinceLevelLoad;
	}

    public void TimeBaahmb()
    {
        //Time.timeScale = timeBaahmbValue;
        //timeBaahmbDuration = Time.timeSinceLevelLoad - Time.deltaTime;
    }
}
