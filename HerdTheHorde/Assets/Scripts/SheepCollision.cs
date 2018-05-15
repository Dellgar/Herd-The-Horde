using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SheepCollision : MonoBehaviour {

	private Sheep sheepScript;
	//private GameManager gmScript;
	private Draggable draggableScript;
	//private SheepMovement movementScript;

	private const int SHEEP_AMOUNT_VALUE = 1;

	[SerializeField]
	private bool isCollidingEnter;

    /*Vector3 rebirthpos;
    public GameObject[] whiteSheepTypes;
    public GameObject[] blackSheepTypes;
    GameObject prefabToSpawn;
    */

    void Awake()
    {
		//gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
		draggableScript = GetComponent<Draggable>();
	}

	private void Update()
	{
		
	}

	IEnumerator PrepareClickedSheepForCollision(GameObject prepareObject)
	{
		sheepScript = prepareObject.GetComponent<Sheep>();
		yield return null;
	}

	public void PrepareForCollision(GameObject prepareMySheep)
	{
		StartCoroutine(PrepareClickedSheepForCollision(prepareMySheep));
	}
   
    /*void OnCollisionEnter2D(Collision2D sheepCollision)
    {
        if (sheepCollision.gameObject.GetComponent<Sheep>().race == "sheepmon")
        {
            if (sheepCollision.gameObject.tag == "sheep") // && sheepScript.race == "sheepmon")
            {
                Debug.Log("Sheepmon collided with " + sheepCollision.gameObject.name);
                rebirthpos = sheepCollision.transform.position;
                DecidePrefab(sheepCollision);
                Destroy(sheepCollision.gameObject);
                Instantiate(prefabToSpawn, rebirthpos, Quaternion.identity);
            }
        }
    }
    */

    void OnTriggerStay2D(Collider2D colGameObject)
    {
        if (draggableScript.isMouseUp)
        {
            if (isCollidingEnter) return;

			if(sheepScript.race == colGameObject.tag || sheepScript.race == "all")
			{
                Debug.Log("Right Pen");
                
                isCollidingEnter = true;
                draggableScript.canDrag = false;

                PenChecker colGameObjChecker = colGameObject.gameObject.GetComponent<PenChecker>();
                
                colGameObjChecker.CorrectPenForSheep(SHEEP_AMOUNT_VALUE);

                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else if(colGameObject.tag == "sheep") // && sheepScript.race == "sheepmon")
            {
                Debug.Log("Trigger collision, game object tag was sheep");
                /*Debug.Log("Sheepmon collided with " + colGameObject.gameObject.name);
                rebirthpos = colGameObject.transform.position;
                DecidePrefab(colGameObject);
                Destroy(colGameObject);
                Instantiate(prefabToSpawn, rebirthpos, Quaternion.identity);
                */
            }
            else
            {
                Debug.Log("Wrong Pen");
                //TODO : when wrong sheep is in the pen, release N amount of sheeps, including the wrong one
                /*
                isCollidingEnter = true;
                movementScript.enabled = false;
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
                //colGameObject.gameObject.GetComponent<PenChecker>().CorrectPenForSheep(-SHEEP_AMOUNT_VALUE);
                //TODO : RELESE THE SHEEPS (AMOUNT OF RELEASED SHEEPS);
                */
            }
        }
	}

    /*void DecidePrefab(Collision2D sheepmonCollision)
    {
        string temptype = sheepmonCollision.gameObject.GetComponent<Sheep>().type;
        string temprace = sheepmonCollision.gameObject.GetComponent<Sheep>().race;
        

        if(temprace == "white")
        {
            if (temptype == "normal")
            {
                prefabToSpawn = blackSheepTypes[0];
            }
        }
    }
    */
}
