using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDeath : MonoBehaviour {

	private GameManager gmScript;
    private SheepMovement moveScript;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    

	[Header ("Death Counter")]
    [SerializeField]
    private double wolfTimer;             // Time when the wolf appears
    public float wolfTimerMin, wolfTimerMax;
    public TextMesh timerText;

	private float initTime;             // Time when object was instantiated
	public float timeSinceInitializition;

	[Header ("Wolf")]
    public bool hasWolfAppeared;        // Wolf for _this_ sheep is in the screen
    
	public GameObject wolfPrefab;       //prefab to spawn
    GameObject badWolf;                 //spawned wolf
    public GameObject wolfSpawnLocation;


    void Start ()
    {
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        moveScript = GetComponent<SheepMovement>();
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        hasWolfAppeared = false;
        timerText = GetComponentInChildren<TextMesh>();

        wolfTimer = System.Math.Round(Random.Range(wolfTimerMin, wolfTimerMax), 1);
        initTime = Time.timeSinceLevelLoad;
	}
	
	void Update ()
    {
        if (wolfSpawnLocation == null) wolfSpawnLocation = GameObject.Find("WolfSpawnLocation");

        if (wolfTimer < wolfTimerMin || wolfTimer > wolfTimerMax) wolfTimer = Random.Range(wolfTimerMin, wolfTimerMax);

        timeSinceInitializition = Time.timeSinceLevelLoad - initTime;

        timerText.text = (wolfTimer - timeSinceInitializition).ToString("F1"); 
        WolfTimerCounter();
	}

    void WolfTimerCounter()
    {
        if(timeSinceInitializition >= wolfTimer)
        {
            //hasWolfAppeared = true;
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;

			if (!hasWolfAppeared)
			{
				//spawns one wolf per sheep
				hasWolfAppeared = true;
				 GameObject badWolf = Instantiate(wolfPrefab, wolfSpawnLocation.transform.position, Quaternion.identity) as GameObject;
                badWolf.name = "Wolfy"; //Sheeplost list
                moveScript.enabled = false;
                rb2D.isKinematic = true;
                //spriteRenderer.enabled = false;

                //this.gameObject.transform.SetParent(badWolf.transform);
                badWolf.GetComponent<Wolf>().WolfStuff(this.transform);
                

                //if wolf is at the sheep then lose one sheep (take .this position due this being the sheep)
                //start moving wolf
                //wolfMoving = true;

				//gmScript.SheepLost(1);
				//disable renderer + rigidbody
				//change wolfsprite
				//go off from screen and destroy sheep

			    //Destroy(this.gameObject);
			}

        }
    }

 



}
