using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggable : MonoBehaviour {

	private GameManager gmScript;
	private Sheep sheepScript;
	private SheepDeath sheepdeathScript;
	private SheepCollision sheepcollScript;


	private Vector3 offset;

    public GameObject mySheep;

	public bool canDrag;
	public bool isMouseUp;
	private bool followingCursor;
	private float dragSens;

    private AudioSource audiosource;
    public AudioClip onclickAudio;

    private void Awake()
    {
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
		sheepcollScript = GetComponent<SheepCollision>();
        audiosource = GetComponent<AudioSource>();

		mySheep = this.gameObject;

		sheepdeathScript = GetComponent<SheepDeath>();

		canDrag = true;
    }

	private void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (followingCursor && canDrag)
        {
			if (dragSens == 0) dragSens = 2f;//Debug.Log("Drag Sensitivity is " + dragSensitivity + " ; 0 Cannot drag");
            mySheep.transform.position = Vector3.MoveTowards(transform.position, cursorPosition, dragSens);
        }
	}

	IEnumerator Save_SheepFromWolf()
	{
		if (gmScript.deadSheepList.Contains(mySheep)) gmScript.SheepRipList("saved", mySheep);
		yield return null;
	}

	IEnumerator Unsave_SheepFromWolf()
	{
		if (!gmScript.deadSheepList.Contains(mySheep)) gmScript.SheepRipList("unsaved", mySheep);
		yield return null;
	}

	void OnMouseDown()
	{
		if (gmScript.gameState == 3)
		{
			//offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
			gmScript.SheepOnCursor(mySheep);

            audiosource.PlayOneShot(onclickAudio, 1f);

			sheepdeathScript.isDeathTimerRunning = false;

			sheepScript = mySheep.GetComponent<Sheep>();
			dragSens = sheepScript.dragSensitivity;

			isMouseUp = false;
			sheepScript.SheepBulge();
			followingCursor = true;

			mySheep.GetComponent<CapsuleCollider2D>().isTrigger = true;

			sheepcollScript.PrepareForCollision(mySheep);

			StartCoroutine("Save_SheepFromWolf");
		}
	}

	/*public void OnMouseDrag()
	{
        if (!canDrag) return;

        if (canDrag)
        {
            Vector2 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

            Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
	}*/

	private void OnMouseUp()
	{
		if (gmScript.gameState == 3)
		{
			sheepdeathScript.isDeathTimerRunning = true;

			isMouseUp = true;
			sheepScript.SheepBulge();
			followingCursor = false;

			mySheep.GetComponent<CapsuleCollider2D>().isTrigger = false;

			//StartCoroutine("Unsave_SheepFromWolf");
		}
	}

}
