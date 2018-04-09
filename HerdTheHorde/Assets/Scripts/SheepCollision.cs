using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SheepCollision : MonoBehaviour {

    public int sheepPointValue = 1;

	//private TextMesh sheepPenText;
	[SerializeField]
	private bool isCollidingEnter;

    private SheepMovement movement_OtherScript;
    private bool isdragging_OtherScript;

    void Awake()
    {
		movement_OtherScript = GetComponent<SheepMovement>();
        
	}

    private void Update()
    {
        isdragging_OtherScript = GetComponent<Draggable>().isDragging;
    }

    void OnTriggerEnter2D(Collider2D colGameObject)
    {
        if (isCollidingEnter) return;

        if (isdragging_OtherScript)
        {
            if (colGameObject.CompareTag(gameObject.tag))
            {
                Debug.Log("Right Pen");
                isCollidingEnter = true;
                colGameObject.gameObject.GetComponent<PenChecker>().CorrectPenForSheep(sheepPointValue);
                movement_OtherScript.enabled = false;
            }
            else
            {
                Debug.Log("Wrong Pen");
                movement_OtherScript.enabled = true;
                colGameObject.gameObject.GetComponent<PenChecker>().CorrectPenForSheep(-1);
            }

            if (!colGameObject.CompareTag(gameObject.tag))
            {    
                isCollidingEnter = false;
            }
        }
	}
	void OnTriggerExit2D(Collider2D colGameObject)
    {    
        //gameObject.GetComponent<Collider2D>().isTrigger = false;
        //movement_OtherScript.enabled = true;
	}

}
