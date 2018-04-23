using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour {

    private GameManager gmScript;

    [Header("Sheep instantiate variables")]
    public bool isWolfOnMove;
    public Vector2 targetSheepPos;
    public Transform targetSheepTrans;

    [Header("Renderer / Sprites")]
    public Sprite wolfKill;
    SpriteRenderer sheepRenderer;
    SpriteRenderer wolfRenderer;
    Animator wolfAnim;

    [Header("Wolf")]
    [Range (0.05f, 3f)]
    public float wolfSpeed;             // Wolf's movement speed
    public bool isWolfLeaving;          // Finished eating, eating other sheeps later, cya!
    public GameObject wolfLeaveLocation;

    private Vector3 targetPosXYZ;
    private GameObject targetSheep;


    private void Start()
    {
        sheepRenderer = targetSheep.GetComponent<SpriteRenderer>();
        wolfRenderer = GetComponent<SpriteRenderer>();
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        wolfAnim = GetComponent<Animator>();
    }

    void Update ()
    {
        //check wolf has leave location and renderer is set
        if (wolfLeaveLocation == null) wolfLeaveLocation = GameObject.Find("WolfLeaveLocation");
        if (sheepRenderer == null) sheepRenderer = targetSheep.GetComponent<SpriteRenderer>();
        if (wolfRenderer == null) wolfRenderer = GetComponent<SpriteRenderer>();

        //target (sheep's) position in vector3
        targetPosXYZ = new Vector3(targetSheepPos.x, targetSheepPos.y, this.transform.position.z);
   
        //wolf is always on move when it has spawned/instantiated through the sheepdeath
        if (isWolfOnMove)
        {

            if (isWolfLeaving)
            {
                Debug.Log("wolf is now leaving");
                wolfAnim.SetInteger("wolfState", 3);
                //wolfRenderer.sprite = wolfKill;

                //wolf is leaving and moving towards leave position
                this.transform.position = Vector2.MoveTowards(this.transform.position, wolfLeaveLocation.transform.position, wolfSpeed);
                if (this.transform.position == wolfLeaveLocation.transform.position)
                {

                    //remove target sheep from riplist
                    gmScript.SheepRipList("dead", targetSheep);

					//count the death only when game is ongoing
					if (gmScript.gameState == 3) gmScript.SheepLost(1);

                    Debug.Log("Destroying wolf /related");
                    //when leaveposition is achieved then destroy the wolf AND the sheep
                    Destroy(targetSheep);
                    Destroy(this.gameObject);
                }
            }

            //move wolf towards the target position
            // else when wolf leaving is false
            else
            {
                Debug.Log("wolf is now attacking");
                wolfAnim.SetInteger("wolfState", 1);

                this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosXYZ, wolfSpeed);
                if (this.transform.position == targetPosXYZ)
                {
                    //when wolf is at the sheep position, disable renderer and let the wolf leave
                    sheepRenderer.enabled = false;
                    wolfAnim.SetInteger("wolfState", 2);
                    Invoke("DustFightCompleted", 1f);

                    
                }
            }
        }
    }

    void DustFightCompleted()
    {
        isWolfLeaving = true;
    }

    public void WolfStuff(Transform target, GameObject sheep)
    {
        isWolfOnMove = true;
        targetSheep = sheep;
        targetSheepTrans = target;
        targetSheepPos = target.position;
    }

}
