using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggable : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

	void OnMouseDown()
	{
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
	}

	void OnMouseDrag()
	{
		Vector2 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}

}
