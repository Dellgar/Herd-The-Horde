using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SheepCollision : MonoBehaviour {

    
    const int SHEEP_AMOUNT_VALUE = 1;

	[SerializeField]
	private bool isCollidingEnter;

    private SheepMovement movementScript;
    private Draggable draggableScript;

    void Awake()
    {
		movementScript = GetComponent<SheepMovement>();
        draggableScript = GetComponent<Draggable>();
    }

    void OnTriggerStay2D(Collider2D colGameObject)
    {
        if (draggableScript.isMouseUp)
        {
            if (isCollidingEnter) return;

            if (colGameObject.CompareTag(gameObject.tag))
            {
                Debug.Log("Right Pen");
                
                isCollidingEnter = true;
                draggableScript.canDrag = false;
                movementScript.enabled = false;
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
                colGameObject.gameObject.GetComponent<PenChecker>().CorrectPenForSheep(SHEEP_AMOUNT_VALUE);
                gameObject.SetActive(false);
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
