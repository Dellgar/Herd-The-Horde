using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour {

    private GameManager gmScript;

    [Header("Renderer")]
    SpriteRenderer wolfRenderer;
    Animator wolfAnim;

    [Header("Wolf")]
    [Range (0.05f, 5f)]
    public float wolfSpeed;             // Wolf's movement speed
    public GameObject wolfLeaveLocation;

    // ** ** //
    public List<GameObject> wolfsTargetList;
    private bool checkingList;
    public Vector3 currentTargetPos;
    public bool isWolfLeaving;

    private AudioSource audioSource;
    public AudioClip dustCloud;
    public AudioClip sheepDied;
    public AudioClip wolfAppear;


    private float wolfPosX;


    private void Start()
    {
        wolfRenderer = GetComponent<SpriteRenderer>();
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        wolfAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

		//check wolf has leave location and renderer is set
		if (wolfLeaveLocation == null) wolfLeaveLocation = GameObject.Find("WolfLeaveLocation");
		if (wolfRenderer == null) wolfRenderer = GetComponent<SpriteRenderer>();

        wolfPosX = transform.position.x;

        StartCoroutine("WolfBehaviour");
    }
	
	void CheckTargetLists()
	{
		Debug.Log("Getting lunch-waypoints from riplist");

		foreach (var obj in gmScript.deadSheepList)
		{
			Debug.Log("wolf's foreach obj: " + obj);
			if (obj != null)
			{
				wolfsTargetList.Add(obj);
				Debug.Log("Added new target for wolf; " + obj.name);
			}
			else
			{
				isWolfLeaving = true;
				StopCoroutine("WolfBehaviour");
			}
		}
		Debug.Log("All objects added for into targetlist");

		//if (gmScript.deadSheepList.Count == 0)
		//{
		//	isWolfLeaving = true;
		//	StopCoroutine("WolfBehaviour");
		//}
	}

	IEnumerator WolfBehaviour()
	{
		yield return new WaitForSeconds(1.3f);

		CheckTargetLists();
        audioSource.PlayOneShot(wolfAppear);
		//set targets
		for (int i = 0; i < wolfsTargetList.Count; i++)
		{
			if (wolfsTargetList[i] == null) wolfsTargetList.RemoveAt(i);
			currentTargetPos = wolfsTargetList[i].transform.position;

			wolfAnim.SetInteger("wolfState", 1);

            if(wolfPosX > currentTargetPos.x)
            {
                wolfRenderer.flipX = true;
            }
            else
            {
                wolfRenderer.flipX = false;
            }

            while (transform.position != currentTargetPos)
			{
				transform.position = Vector3.MoveTowards(transform.position, currentTargetPos, wolfSpeed * 10 * Time.deltaTime);
				yield return null;
			}

			Debug.Log("Wolf moves towards target: " + wolfsTargetList[i]);

			//wolf is at the target position
			if (transform.position == currentTargetPos)
			{
                //Set new posX for flipping
                wolfPosX = transform.position.x;

                //check if sheep still exists in riplist
                if (gmScript.deadSheepList.Contains(wolfsTargetList[i]))
				{
					Debug.Log("slashing");
					wolfAnim.SetInteger("wolfState", 2);
                    yield return new WaitForSeconds(wolfAnim.GetCurrentAnimatorClipInfo(0).Length - 0.5f);

                    Debug.Log("dustcloud");
                    wolfAnim.SetInteger("wolfState", 3);
                    audioSource.PlayOneShot(dustCloud);
                    yield return new WaitForSeconds(0.4f);
                    audioSource.PlayOneShot(sheepDied);

                    Debug.Log("hunting");
                    wolfAnim.SetInteger("wolfState", 1);
                    

                    Debug.Log("wolf target found from riplist");

					wolfsTargetList[i].GetComponent<SpriteRenderer>().enabled = false;
					wolfsTargetList[i].GetComponent<PolygonCollider2D>().enabled = false;
					wolfsTargetList[i].GetComponent<CapsuleCollider2D>().enabled = false;

                    //Removing from list, because sheep is now fucking gone, man
                    gmScript.SheepLost(1);
                    gmScript.deadSheepList.Remove(wolfsTargetList[i]);

					yield return new WaitForSeconds(0.1f);
				}
				else
				{
					//Sheep was probably saved before wolf killed it
					Debug.Log("Sheep not found from riplist - what happened");
					wolfsTargetList.Remove(wolfsTargetList[i]);

				}

				Debug.Log("for index " + i);

				//targetlist is finished, go away you wolf!
				if (i >= wolfsTargetList.Count-1)
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
			wolfAnim.SetInteger("wolfState", 4);

			transform.position = Vector2.MoveTowards(transform.position, wolfLeaveLocation.transform.position, wolfSpeed * 20 * Time.deltaTime);

			if (transform.position == wolfLeaveLocation.transform.position)
			{
				gmScript.hasWolfSpawned = false;
				Destroy(this.gameObject);
			}
		}
	}

}
