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

	IEnumerator PrepareClickedSheepForCollision(GameObject prepareObject)
	{
		sheepScript = prepareObject.GetComponent<Sheep>();
		yield return null;
	}

	public void PrepareForCollision(GameObject prepareMySheep)
	{
		StartCoroutine(PrepareClickedSheepForCollision(prepareMySheep));
	}
   
    void OnTriggerStay2D(Collider2D colGameObject)
    {
        if (draggableScript.isMouseUp)
        {
            if (isCollidingEnter) return;

            if (sheepScript.race == colGameObject.tag)// || sheepScript.race == "all")
			{
                Debug.Log("Right Pen");
                
                isCollidingEnter = true;
                draggableScript.canDrag = false;

                PenChecker colGameObjChecker = colGameObject.gameObject.GetComponent<PenChecker>();
                
                colGameObjChecker.CorrectPenForSheep(SHEEP_AMOUNT_VALUE);

                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else if(colGameObject.tag == "sheep")
            {
                Debug.Log("Trigger collision, game object tag was sheep");

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
                //TODO : RELEASE THE SHEEPS (AMOUNT OF RELEASED SHEEPS);
                */
            }
        }
	}
}
