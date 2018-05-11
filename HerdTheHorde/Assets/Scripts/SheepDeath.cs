using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDeath : MonoBehaviour {

	private GameManager gmScript;
    private SheepMovement moveScript;
	private Animator sheepAnim;

	[Header ("Death Counter")]
    [SerializeField]
    private float wolfTimer;             // Time when the wolf appears
    public float wolfTimerMin, wolfTimerMax;

	[Header ("Wolf")]
	public GameObject wolfPrefab;       //prefab to spawn
    public GameObject wolfSpawnLocation;


    void Start ()
    {
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        moveScript = GetComponent<SheepMovement>();
		sheepAnim = GetComponent<Animator>();

        wolfTimer = Random.Range(wolfTimerMin, wolfTimerMax);

		Invoke("WolfTimerCounter", wolfTimer);
	}
	
	void Update ()
    {
        if (wolfSpawnLocation == null) wolfSpawnLocation = GameObject.Find("WolfSpawnLocation");
	}

    void WolfTimerCounter()
    {
        //disabling moving but not interaction
        moveScript.DisableMoving();

        if(!gmScript.deadSheepList.Contains(this.gameObject)) gmScript.SheepRipList("timeup", this.gameObject);

        sheepAnim.SetBool("isHorrified", true);

        if (!gmScript.hasWolfSpawned)
        {
            //spawns one wolf per sheep for now (bool check)
            gmScript.hasWolfSpawned = true;

            GameObject badWolf = Instantiate(wolfPrefab, wolfSpawnLocation.transform.position, Quaternion.identity) as GameObject;
            badWolf.name = "Wolfy"; //Take sheep from Sheeplost list?
        }
    }

}
