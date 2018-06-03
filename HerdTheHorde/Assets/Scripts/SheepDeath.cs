using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDeath : MonoBehaviour {

	private GameManager gmScript;
    private SheepMovement moveScript;
	private Animator sheepAnim;
	private Sheep sheepScript;

	[Header ("Death Counter")]
    [SerializeField]
    private float wolfTimer;             // Time when the wolf appears
    public float wolfTimerMin, wolfTimerMax;
	private bool isSheepTimeUp;

	private float initTime;
	[SerializeField]
	private float timeSinceInit;
	public bool isDeathTimerRunning;

	[Header ("Wolf")]
	public GameObject wolfPrefab;       //prefab to spawn
    public GameObject wolfSpawnLocation;


    void Start ()
    {
		sheepScript = GetComponent<Sheep>();
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        moveScript = GetComponent<SheepMovement>();
		sheepAnim = GetComponent<Animator>();

		isDeathTimerRunning = true;
		isSheepTimeUp = false;
        wolfTimer = Random.Range(wolfTimerMin, wolfTimerMax);
		initTime = Time.timeSinceLevelLoad;
        //Invoke("WolfTimerCounter", wolfTimer);

        if (wolfSpawnLocation == null) wolfSpawnLocation = GameObject.Find("WolfSpawnLocation");
    }

    void FixedUpdate ()
    {
		if(isDeathTimerRunning)	timeSinceInit = Time.timeSinceLevelLoad - initTime;

		if(timeSinceInit >= wolfTimer && !isSheepTimeUp)
		{
			isSheepTimeUp = true;
			WolfTimerCounter();
		}

	}

    void WolfTimerCounter()
    {
        //disabling moving but not interaction
        moveScript.DisableMoving();
		if(sheepScript.type == "sheepmon")
		{
			sheepAnim.SetBool("isHorrified", true);
			Destroy(this.gameObject, 0.7f);
		}
		else
		{
			if(!gmScript.deadSheepList.Contains(this.gameObject)) gmScript.SheepRipList("timeup", this.gameObject);

			sheepAnim.SetBool("isHorrified", true);

			if (!gmScript.hasWolfSpawned)
			{
				gmScript.hasWolfSpawned = true;

				GameObject badWolf = Instantiate(wolfPrefab, wolfSpawnLocation.transform.position, Quaternion.identity) as GameObject;
				badWolf.name = "Wolfy";
			}
		}

    }

}
