using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDeath : MonoBehaviour {

	private GameManager gmScript;

	[Header ("Death Counter")]
    [SerializeField]
    private double wolfTimer;             // Time when the wolf appears
    public float wolfTimerMin, wolfTimerMax;
    public TextMesh timerText;

	private float initTime;             // Time when object was instantiated
	public float timeSinceInitializition;

	[Header ("Wolf")]
    public bool hasWolfAppeared;        // Wolf for _this_ sheep is in the screen
    public float wolfSpeed;             // Wolf's movement speed
    public bool isWolfEating;           // RIP ;_;
    public bool isWolfLeaving;          // Finished eating, eating other sheeps later, cya!

	public Sprite wolfAttack;
	public Sprite wolfKill;
	public GameObject wolfPrefab;
	public GameObject wolfSpawnLocation;


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
				Instantiate(wolfPrefab, wolfSpawnLocation.transform.position, Quaternion.identity);

				//if wolf is at the sheep then lose one sheep (take .this position due this being the sheep)
				gmScript.SheepLost(1);
				//disable renderer + rigidbody
				//change wolfsprite
				//go off from screen and destroy sheep

				Destroy(this.gameObject);
			}

        }
    }



}
