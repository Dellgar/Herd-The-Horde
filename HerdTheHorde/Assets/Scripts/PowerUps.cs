using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUps : MonoBehaviour {

	private GameManager gmScript;

	[Header("Buttons")]
	public Button[] powerUpBtns;

	[Header("TimeBaahmb")]
	public bool isActiveTimeBaahmb;
	[Range(0.1f , 1f)]
    public float timeBaahmbValue;
    public float timeBaahmbDuration;
	public GameObject TimeActiveIcon;
    public GameObject HourglassSpin;


    [Header("Dog")]
	public bool isActiveDoggy;
	public float DogDuration;
	public GameObject DogActiveIcon;
    public GameObject DogWoofing;




	private void Awake()
	{
		gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
	}

    public void PU_TimeBaahmb()
    {
		StartCoroutine("Timeslow");
	}

	public void PU_ShepherdDog()
	{
		StartCoroutine("Sheepdoggy");
	}

	IEnumerator Timeslow()
	{
		isActiveTimeBaahmb = true;

		Time.timeScale = timeBaahmbValue;

        HourglassSpin.SetActive(true);
        TimeActiveIcon.SetActive(true);

		powerUpBtns[0].interactable = false;

		yield return new WaitForSeconds(timeBaahmbDuration);

		Time.timeScale = 1f;

		TimeActiveIcon.SetActive(false);

        HourglassSpin.SetActive(false);
        powerUpBtns[0].interactable = true;

		yield return null;
	}

	IEnumerator Sheepdoggy()
	{
		isActiveDoggy = true;

		gmScript.hasWolfSpawned = true;

        DogWoofing.SetActive(true);
		DogActiveIcon.SetActive(true);

        powerUpBtns[1].interactable = false;

		yield return new WaitForSeconds(DogDuration);

		gmScript.hasWolfSpawned = false;

        DogWoofing.SetActive(false);
        DogActiveIcon.SetActive(false);

        powerUpBtns[1].interactable = true;

		yield return null;
	}
}
