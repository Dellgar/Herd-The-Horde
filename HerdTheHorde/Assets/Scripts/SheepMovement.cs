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
		//Accessing to components with variables
        myRigidbody = GetComponent<Rigidbody2D>();
		sheepRenderer = GetComponent<SpriteRenderer>();
		mainCam = Camera.main;
        
		//Set counters
        waitCounter = waitTime;
        moveCounter = moveTime;

		//Allow sheeps first direction to be:
		//up right down or right
		moveDirection = Random.Range(0, 4);
	}
	
	// Update is called once per frame
	void Update ()
    {
		//Store what is the coordinate of sheep in viewport-coordinates
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
		//Check if out from screen bounds that is set in CameraBoundaries(), and if sheep is outside
		//then force the movedirection to be opposite of that, making the sheeps coming back into the screen
		if (!isInScreen)
		{
			if (viewportPos.x > 0.9f)
			{
				moveDirection = 3;
			}
			if (viewportPos.x < 0.1f)
			{
				moveDirection = 1;
			}

			if (viewportPos.y > 0.9f)
			{
				moveDirection = 2;
			}
			if (viewportPos.y < 0.1f)
			{
				moveDirection = 0;
			}
		}
		//If the sheeps are in screen bounds, then randomize movedirection
		else
		{
			moveDirection = Random.Range(0, 8);
		}

		isMoving = true;
		moveCounter = moveTime;
    }

	//Set screen bounds, where if sheeps wander outside they are forced to take movedirection leading them back
	public void CameraBoundaries()
	{
		if (viewportPos.x <= 0.9f && viewportPos.x >= 0.1f && 
			viewportPos.y <= 0.9f && viewportPos.y >= 0.1f)
		{
			//Debug.Log("In Screen");
			isInScreen = true;
		}
		else
		{
			//Debug.Log("Not in screen");
			isInScreen = false;
		}
	}
}
