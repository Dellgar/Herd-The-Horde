using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplSetups : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

		Application.targetFrameRate = 35;

		QualitySettings.vSyncCount = 0;

		QualitySettings.antiAliasing = 0;

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}
}
