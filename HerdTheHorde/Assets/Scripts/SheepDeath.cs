using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDeath : MonoBehaviour {

    public float wolfTimer;             // Time when the wolf appears
    public TextMesh timerText;

    public bool hasWolfAppeared;        // Wolf for _this_ sheep is in the screen
    public float wolfSpeed;             // Wolf's movement speed
    public bool isWolfEating;           // RIP ;_;
    public bool isWolfLeaving;          // Finished eating, eating other sheeps later, cya!

    private float initTime;             // Time since object was instantiated
    public float timeSinceInitializition;

    private GameManager gmScript;



    void Start ()
    {
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();

        hasWolfAppeared = false;
        isWolfEating = false;
        isWolfLeaving = false;
        timerText = GetComponentInChildren<TextMesh>();

        initTime = Time.timeSinceLevelLoad;
	}
	
	void Update ()
    {
        timeSinceInitializition = Time.timeSinceLevelLoad - initTime;
        
        timerText.text = Mathf.Round(timeSinceInitializition).ToString(); 
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
