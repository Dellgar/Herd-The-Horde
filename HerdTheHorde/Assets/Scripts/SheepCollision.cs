using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SheepCollision : MonoBehaviour {

    
    private const int SHEEP_AMOUNT_VALUE = 1;

	[SerializeField]
	private bool isCollidingEnter;

    //private SheepMovement movementScript;
    private Draggable draggableScript;

    void Awake()
    {
        draggableScript = GetComponent<Draggable>();
    }

    void OnTriggerStay2D(Collider2D colGameObject)
    {
        if (draggableScript.isMouseUp)
        {
            if (isCollidingEnter) return;

            if (colGameObject.CompareTag(gameObject.tag) && colGameObject.name == "whitePen" || colGameObject.name == "blackPen")   //paskaa koodia, vaiha ja tee tagit lammas skriptiin
            {
                Debug.Log("Right Pen");
                
                isCollidingEnter = true;
                draggableScript.canDrag = false;
                //movementScript.enabled = false;
                
                // Error; object reference not set
                //colGameObject.gameObject.GetComponent<PenChecker>().CorrectPenForSheep(SHEEP_AMOUNT_VALUE);
                PenChecker colGameObjChecker = colGameObject.gameObject.GetComponent<PenChecker>();
                
                colGameObjChecker.CorrectPenForSheep(SHEEP_AMOUNT_VALUE);

                gameObject.SetActive(false);
                Destroy(gameObject);
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
}
