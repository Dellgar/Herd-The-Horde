using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour {

    public float moveSpeed;
	public Camera mainCam;
    private Rigidbody2D myRigidbody;
    public bool isMoving;
    public float moveTime;
    private float moveCounter;
    public float waitTime;
    private float waitCounter;
    private int moveDirection;
    private SpriteRenderer sheepRenderer;

	[SerializeField]
	private Vector2 viewportPos;

	private bool isInScreen;


	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
        sheepRenderer = GetComponent <SpriteRenderer>();
		

        waitCounter = waitTime;
        moveCounter = moveTime;

        ChooseDirection();
	}
	
	// Update is called once per frame
	void Update ()
    {
		viewportPos = mainCam.WorldToViewportPoint(transform.position);
		CameraBoundaries();

		if (isMoving)
        {
            moveCounter -= Time.deltaTime;

            switch (moveDirection)
            {
            case 0: //upwards
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
					break;

            case 1: //right
                    sheepRenderer.flipX = true;
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    break;

            case 2: //downwards
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    break;

            case 3: //left
                    sheepRenderer.flipX = false;
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    break;
            case 4: //up right
                    myRigidbody.velocity = new Vector2(moveSpeed, moveSpeed);
                    break;
            case 5: //down left
                    myRigidbody.velocity = new Vector2(-moveSpeed, -moveSpeed);
                    break;
            case 6: // down right
                    myRigidbody.velocity = new Vector2(moveSpeed, -moveSpeed);
                    break;
            case 7: // up left
                    myRigidbody.velocity = new Vector2(-moveSpeed, moveSpeed);
                    break;
            }

			if (moveCounter < 0)
            {
                isMoving = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
		//check if out from screen
		if (!isInScreen)
		{
			if (viewportPos.x > 0.8f)
			{
				moveDirection = 3;
			}
			if (viewportPos.x < 0f)
			{
				moveDirection = 1;
			}

			if (viewportPos.y > 1f)
			{
				moveDirection = 2;
			}
			if (viewportPos.y < 0f)
			{
				moveDirection = 0;
			}
		}
		else
		{
			moveDirection = Random.Range(0, 8);
		}

		isMoving = true;
		moveCounter = moveTime;
		
    }

	public void CameraBoundaries()
	{

		if (viewportPos.x <= 0.8f && viewportPos.x >= 0f && 
			viewportPos.y <= 1f && viewportPos.y >= 0f)
		{
			Debug.Log("In Screen");
			isInScreen = true;
		}
		else
		{
			Debug.Log("Not in screen");
			isInScreen = false;
		}
	}
}
