using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggable : MonoBehaviour {

	private Vector3 offset;
    public bool canDrag;
    public bool isMouseUp;

    public Sheep sheepScript;
    private GameManager gmScript;

    public GameObject mySheep;

    private bool followingCursor;

    private bool wasSaved;

    

    private void Awake()
    {
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        sheepScript = GetComponent<Sheep>();
        canDrag = true;
        mySheep = this.gameObject;
    }

    private void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (followingCursor && canDrag)
        {
            mySheep.transform.position = Vector3.MoveTowards(transform.position, cursorPosition, 0.2f);
        }

        
        if (wasSaved)
        {
            if (gmScript.deadSheepList.Contains(mySheep)) gmScript.SheepRipList("saved", mySheep);
            else return;

        }
        else if (!wasSaved)
        {
            if (!gmScript.deadSheepList.Contains(mySheep)) gmScript.SheepRipList("unsaved", mySheep);
            else return;
        }
        
    }



    void OnMouseDown()
	{
		//offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        isMouseUp = false;
        sheepScript.SheepBulge();

        followingCursor = true;

        wasSaved = true;
        
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
        isMouseUp = true;
        sheepScript.SheepBulge();
        followingCursor = false;

        wasSaved = false;
    }



}
