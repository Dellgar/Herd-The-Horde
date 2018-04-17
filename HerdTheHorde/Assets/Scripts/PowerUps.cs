using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    [Range(0.1f , 1f)]
    public float timeBaahmbValue;
    public float timeBaahmbDuration;
	private float baahmbHelper;
	bool isActiveTimeBaahmb;
    private float currentTime;
	private float buttonpressTime;

    private void Start()
    {
        buttonpressTime = 0;
    }

    void Update ()
    {
		currentTime = Time.timeSinceLevelLoad;

		if (isActiveTimeBaahmb)
		{
			Time.timeScale = timeBaahmbValue;
			timeBaahmbDuration -= Time.deltaTime;
			if (timeBaahmbDuration <= 0)
			{
				isActiveTimeBaahmb = !isActiveTimeBaahmb;
				timeBaahmbDuration = baahmbHelper;
                Time.timeScale = 1;
            }
		}

	}

    public void TimeBaahmb()
    {
		buttonpressTime = currentTime;
		baahmbHelper = timeBaahmbDuration;
		isActiveTimeBaahmb = true;
    }
}
