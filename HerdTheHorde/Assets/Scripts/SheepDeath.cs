using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDeath : MonoBehaviour {

	private GameManager gmScript;
    private SheepMovement moveScript;
    private Rigidbody2D rb2D;
	private Animator sheepAnim;

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
		sheepAnim = GetComponent<Animator>();

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

        //timerText.text = "";
        //timerText.text = (wolfTimer - timeSinceInitializition).ToString("F1"); 
        WolfTimerCounter();
	}

    void WolfTimerCounter()
    {
        if(timeSinceInitializition >= wolfTimer)
        {
			if (!hasWolfAppeared)
			{
				//spawns one wolf per sheep
				hasWolfAppeared = true;
                gmScript.SheepRipList("timeup", this.gameObject);

                //moveScript.enabled = false;
                rb2D.simulated = false;
				sheepAnim.SetBool("isHorrified", true);
				//rb2D.isKinematic = true;
				//rb2D.constraints = RigidbodyConstraints2D.FreezePosition;

				GameObject badWolf = Instantiate(wolfPrefab, wolfSpawnLocation.transform.position, Quaternion.identity) as GameObject;
                badWolf.name = "Wolfy"; //Take sheep from Sheeplost list?

                badWolf.GetComponent<Wolf>().WolfStuff(this.transform, this.gameObject);
			}
        }
    }

}
