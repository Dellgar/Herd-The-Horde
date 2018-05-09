using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour {

    private GameManager gmScript;

    [Header("Sheep instantiate variables")]
    public bool isWolfOnMove;
    public Vector2 targetSheepPos;
    public Transform targetSheepTrans;

    [Header("Renderer / Sprites")]
    public Sprite wolfKill;
    SpriteRenderer sheepRenderer;
    SpriteRenderer wolfRenderer;
    Animator wolfAnim;

    [Header("Wolf")]
    [Range (0.05f, 3f)]
    public float wolfSpeed;             // Wolf's movement speed
    public GameObject wolfLeaveLocation;

    private Vector3 targetPosXYZ;
    private GameObject targetSheep;



    // ** ** //
    public List<GameObject> wolfsTargetList;
    private bool checkingList;
    public Vector3 currentTargetPos;
    public bool isWolfLeaving;



    private void Start()
    {
        //sheepRenderer = targetSheep.GetComponent<SpriteRenderer>();
        wolfRenderer = GetComponent<SpriteRenderer>();
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        wolfAnim = GetComponent<Animator>();

		//check wolf has leave location and renderer is set
		if (wolfLeaveLocation == null) wolfLeaveLocation = GameObject.Find("WolfLeaveLocation");
		if (wolfRenderer == null) wolfRenderer = GetComponent<SpriteRenderer>();

		//checkingList = false;
		

		StartCoroutine("WolfBehaviour");
    }
	
	void CheckTargetLists()
	{

		Debug.Log("Getting lunch-waypoints from riplist");

		foreach (var obj in gmScript.deadSheepList)
		{
			if (obj != null)
			{
				wolfsTargetList.Add(obj);
				Debug.Log("Added new target for wolf; " + obj.name);
			}
		}
	}

	IEnumerator WolfBehaviour()
	{
		yield return new WaitForSeconds(0.5f);
		CheckTargetLists();

		//set targets
		for (int i = 0; i < wolfsTargetList.Count; i++)
		{
			currentTargetPos = wolfsTargetList[i].transform.position;


			wolfAnim.SetInteger("wolfState", 1);
			while (transform.position != currentTargetPos)
			{
				transform.position = Vector2.MoveTowards(transform.position, currentTargetPos, wolfSpeed * 10 * Time.deltaTime);
				yield return null;
			}

			Debug.Log("Wolf moves towards target: " + wolfsTargetList[i]);

			//wolf is at the target position
			if (transform.position == currentTargetPos)
			{
				//check if sheep still exists in riplist
				if (gmScript.deadSheepList.Contains(wolfsTargetList[i]))
				{
					Debug.Log("wolf AT TARGET, dustcloud");
					wolfAnim.SetInteger("wolfState", 2);

					Debug.Log("wolf target found from riplist");

					wolfsTargetList[i].GetComponent<SpriteRenderer>().enabled = false;
					wolfsTargetList[i].GetComponent<PolygonCollider2D>().enabled = false;
					wolfsTargetList[i].GetComponent<CapsuleCollider2D>().enabled = false;

					//Removing from list, because sheep is now fucking gone, man
					gmScript.deadSheepList.Remove(wolfsTargetList[i]);

					yield return new WaitForSeconds(1f);
				}
				else
				{
					//Sheep was probably saved before wolf killed it
					Debug.Log("Sheep not found from riplist - what happened");
				}

				Debug.Log("for index " + i);

				//targetlist is finished, go away you wolf!
				if (i == wolfsTargetList.Count-1)
				{

					foreach (var target in wolfsTargetList)
					{
						Destroy(target);
					}

					Debug.Log("targets eliminated");
					isWolfLeaving = true;
				}
			}
			//next target
		}
		yield return null;
	}

	void Update()
	{
		if (isWolfLeaving)
		{
			wolfAnim.SetInteger("wolfState", 3);

			transform.position = Vector2.MoveTowards(transform.position, wolfLeaveLocation.transform.position, wolfSpeed * 20 * Time.deltaTime);
			//currentTargetPos = wolfLeaveLocation.transform.position;

			if (transform.position == wolfLeaveLocation.transform.position)
			{
				gmScript.hasWolfSpawned = false;
				Destroy(this.gameObject);
			}
		}
	}

		/*
		void Update ()
		{
			if (isWolfLeaving)
			{
				wolfAnim.SetInteger("wolfState", 3);

				transform.position = Vector2.MoveTowards(transform.position, wolfLeaveLocation.transform.position, wolfSpeed * 2 * Time.deltaTime);
				//currentTargetPos = wolfLeaveLocation.transform.position;

				if (transform.position == wolfLeaveLocation.transform.position)
				{
					gmScript.hasWolfSpawned = false;
					Destroy(this);
				}
			}

			// Target list checked and updated, lets go for a hunt
			if (isWolfOnMove)    //set through sheep's death
			{

				//check wolf has leave location and renderer is set
				if (wolfLeaveLocation == null) wolfLeaveLocation = GameObject.Find("WolfLeaveLocation");
				//if (sheepRenderer == null) sheepRenderer = targetSheep.GetComponent<SpriteRenderer>();
				if (wolfRenderer == null) wolfRenderer = GetComponent<SpriteRenderer>();


				//start checking riplist
				if (!checkingList)
				{
					Debug.Log("Getting lunch-waypoints from riplist");
					checkingList = true;

					foreach (var obj in gmScript.deadSheepList)
					{
						wolfsTargetList.Add(obj);
						Debug.Log("Added new target for wolf; " + obj.name);
					}
				}

				//set targets
				for (int i = 0; i < wolfsTargetList.Count; i++)
				{
					currentTargetPos = wolfsTargetList[i].transform.position;


					wolfAnim.SetInteger("wolfState", 1);
					transform.position = Vector2.MoveTowards(transform.position, currentTargetPos, wolfSpeed * 5 * Time.deltaTime);
					Debug.Log("Wolf moves towards target: " + wolfsTargetList[i]);

					if (transform.position == currentTargetPos)
					{
						Debug.Log("wolf AT TARGET, dustcloud");
						//wolf is at the target position

						wolfAnim.SetInteger("wolfState", 2);

						//check if sheep still exists in riplist
						if (gmScript.deadSheepList.Contains(wolfsTargetList[i]))
						{
							Debug.Log("wolf target found from riplist");

							wolfsTargetList[i].GetComponent<SpriteRenderer>().enabled = false;

							//Removing from lists, because sheep is now fucking gone, man
							gmScript.deadSheepList.Remove(wolfsTargetList[i]);
							wolfsTargetList.Remove(wolfsTargetList[i]);
						}
						else
						{
							//Sheep was probably saved before wolf killed it
							Debug.Log("Sheep not found from riplist - what happened");
						}

						Debug.Log("for index " + i);

						//targetlist is finished, go away you wolf!
						if (i == wolfsTargetList.Count)
						{
							//Removing from lists, because sheep is now fucking gone, man
							//gmScript.deadSheepList.Remove(wolfsTargetList[i]);
							//wolfsTargetList.Remove(wolfsTargetList[i]);

							Debug.Log("targets eliminated");
							isWolfLeaving = true;

						}
					}

					//next target [i]
				}
			}




			//lulul
			//target (sheep's) position in vector3
			targetPosXYZ = new Vector3(targetSheepPos.x, targetSheepPos.y, this.transform.position.z);


			//wolf is always on move when it has spawned/instantiated through the sheepdeath
			if (isWolfOnMove)
			{

				if (isWolfLeaving)
				{
					Debug.Log("wolf is now leaving");
					wolfAnim.SetInteger("wolfState", 3);
					//wolfRenderer.sprite = wolfKill;

					//wolf is leaving and moving towards leave position
					this.transform.position = Vector2.MoveTowards(this.transform.position, wolfLeaveLocation.transform.position, wolfSpeed);
					if (this.transform.position == wolfLeaveLocation.transform.position)
					{
						//remove target sheep from riplist
						gmScript.SheepRipList("dead", targetSheep);

						//count the death only when game is ongoing
						if (gmScript.gameState == 3) gmScript.SheepLost(1);

						Debug.Log("Destroying wolf /related");
						//when leaveposition is achieved then destroy the wolf AND the sheep
						Destroy(targetSheep);
						Destroy(this.gameObject);
					}
				}

				//move wolf towards the target position
				// else when wolf leaving is false
				else
				{
					Debug.Log("wolf is now attacking");
					wolfAnim.SetInteger("wolfState", 1);

					this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosXYZ, wolfSpeed);
					if (this.transform.position == targetPosXYZ)
					{
						//when wolf is at the sheep position, disable renderer and let the wolf leave
						sheepRenderer.enabled = false;
						wolfAnim.SetInteger("wolfState", 2);
						Invoke("DustFightCompleted", 1f);


					}
				}
			}

		}*/



		public void WolfStuff(Transform target, GameObject sheep)
    {
        isWolfOnMove = true;
        //targetSheep = sheep;
        //targetSheepTrans = target;
        //targetSheepPos = target.position;
    }

}
