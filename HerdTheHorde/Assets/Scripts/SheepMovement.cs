using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour {

    private GameManager gmScript;

    private Animator sheepAnim;

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


	void Start ()
    {
        //Accessing to components with variables
        sheepAnim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
		sheepRenderer = GetComponent<SpriteRenderer>();
		mainCam = Camera.main;
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        
		//Set counters
        waitCounter = waitTime;
        moveCounter = moveTime;

		//Allow sheeps first direction to be:
		//up right down or right
		moveDirection = Random.Range(0, 4);
	}
	
	void Update ()
    {
		//Store what is the coordinate of sheep in the viewport-coordinates
		viewportPos = mainCam.WorldToViewportPoint(transform.position);
		CameraBoundaries();

        CheckAnimation();

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
                    sheepRenderer.flipX = true;
                    myRigidbody.velocity = new Vector2(moveSpeed, moveSpeed);
                    break;

            case 5: //down left
                    sheepRenderer.flipX = false;
                    myRigidbody.velocity = new Vector2(-moveSpeed, -moveSpeed);
                    break;

            case 6: // down right
                    sheepRenderer.flipX = true;
                    myRigidbody.velocity = new Vector2(moveSpeed, -moveSpeed);
                    break;

            case 7: // up left
                    sheepRenderer.flipX = false;
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
			if (viewportPos.x > gmScript.sheepAllowedArea[1].x)     //if sheep X is greater than allowable X
			{
				moveDirection = 3;  //left
			}

			if (viewportPos.x < gmScript.sheepAllowedArea[0].x)     //if sheep X is less than allowable X
            {
				moveDirection = 1;  //right
			}

			if (viewportPos.y > gmScript.sheepAllowedArea[0].y)
			{
				moveDirection = 2;  //down
			}

			if (viewportPos.y < gmScript.sheepAllowedArea[1].y)
			{
                moveDirection = 0;  //up
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
		if (viewportPos.x <= gmScript.sheepAllowedArea[1].x && viewportPos.x >= gmScript.sheepAllowedArea[0].x && 
			viewportPos.y <= gmScript.sheepAllowedArea[0].y && viewportPos.y >= gmScript.sheepAllowedArea[1].y)
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

    public void CheckAnimation()
    {
        if (isMoving)
        {
            sheepAnim.SetBool("isWalking", true);    
        }
        else
        {
            sheepAnim.SetBool("isWalking", false);
        }
    }
}
