using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDecorsZ : MonoBehaviour {
	private Camera mainCam;
	private Vector2 viewportPos;


	[ExecuteInEditMode]
	void Update () {
		mainCam = Camera.main;
		viewportPos = mainCam.WorldToViewportPoint(transform.position);

		float clampedViewportPosY = Mathf.Clamp(viewportPos.y, 0f, 1f);

		Vector3 minXY = mainCam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
		Vector3 maxXY = mainCam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));


		float posZ = Mathf.Lerp(3f, 6f, clampedViewportPosY);
		float posY = Mathf.Clamp(transform.position.y, (minXY.y), (maxXY.y));

		transform.position = new Vector3(transform.position.x, posY, posZ);
	}
}
