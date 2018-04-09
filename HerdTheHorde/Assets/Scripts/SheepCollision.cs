using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SheepCollision : MonoBehaviour {

    public int sheepPointValue = 1;

	//private TextMesh sheepPenText;
	[SerializeField]
	private bool isCollidingEnter;

    private SheepMovement movement_OtherScript;

    void Awake()
    {
		movement_OtherScript = GetComponent<SheepMovement>();
	}

    void OnTriggerEnter2D(Collider2D colGameObject)
    {
		if (isCollidingEnter) return;

		isCollidingEnter = true;
        if (colGameObject.CompareTag(gameObject.tag))
        {
            Debug.Log("Right Pen");
            colGameObject.gameObject.GetComponent<PenChecker>().CorrectPenForSheep(sheepPointValue);
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            movement_OtherScript.enabled = false;
        }
        else
		{
			Debug.Log("Wrong Pen");
		}
	}
	void OnTriggerExit2D(Collider2D colGameObject)
    {    
        //gameObject.GetComponent<Collider2D>().isTrigger = false;
        //movement_OtherScript.enabled = true;
	}

}
