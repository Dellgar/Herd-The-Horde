using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDeath : MonoBehaviour {

    [SerializeField]
    private double wolfTimer;             // Time when the wolf appears
    public float wolfTimerMin, wolfTimerMax;
    public TextMesh timerText;

    public bool hasWolfAppeared;        // Wolf for _this_ sheep is in the screen
    public float wolfSpeed;             // Wolf's movement speed
    public bool isWolfEating;           // RIP ;_;
    public bool isWolfLeaving;          // Finished eating, eating other sheeps later, cya!

    private float initTime;             // Time when object was instantiated
    public float timeSinceInitializition;

    private GameManager gmScript;



    void Start ()
    {
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();

        hasWolfAppeared = false;
        isWolfEating = false;
        isWolfLeaving = false;
        timerText = GetComponentInChildren<TextMesh>();

        wolfTimer = System.Math.Round(Random.Range(wolfTimerMin, wolfTimerMax), 1);
        initTime = Time.timeSinceLevelLoad;
	}
	
	void Update ()
    {
        if (wolfTimer < wolfTimerMin || wolfTimer > wolfTimerMax) wolfTimer = Random.Range(wolfTimerMin, wolfTimerMax);

        timeSinceInitializition = Time.timeSinceLevelLoad - initTime;

        timerText.text = (wolfTimer - timeSinceInitializition).ToString("F1"); // Mathf.Round(timeSinceInitializition).ToString(); 
        WolfTimerCounter();
	}

    void WolfTimerCounter()
    {

        if(timeSinceInitializition >= wolfTimer)
        {
            hasWolfAppeared = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            gmScript.SheepLost(1);

            Destroy(this.gameObject);
        }

    }
}
