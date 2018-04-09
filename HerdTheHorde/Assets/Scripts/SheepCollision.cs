using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SheepCollision : MonoBehaviour {

    public int sheepCount;

	//private TextMesh sheepPenText;
	[SerializeField]
	private bool isColliding;

	private SheepMovement movement_OtherScript;

    void Awake() {
		movement_OtherScript = GetComponent<SheepMovement>();
	}

	void Start() {

	}

	void Update() {

	}

    void OnTriggerEnter2D(Collider2D colGameObject) {
		if (isColliding) return;

		isColliding = true;
		movement_OtherScript.enabled = false;
		if (colGameObject.CompareTag(gameObject.tag))
		{
			//sheepCount++;
			Debug.Log("Right Pen");
			gameObject.GetComponent<Collider2D>().isTrigger = true;
		}
		else
		{
			Debug.Log("Wrong Pen");
		}
	}
	void OnTriggerExit2D(Collider2D colGameObject) {
		//movement_OtherScript.enabled = true;
	}

}
