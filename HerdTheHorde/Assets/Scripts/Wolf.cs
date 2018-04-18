using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour {

    public bool isWolfOnMove;
    public Vector2 targetSheepPos;
    public Transform targetSheepTrans;

    public Sprite wolfAttack;
    public Sprite wolfKill;

    [Range (0.05f, 3f)]
    public float wolfSpeed;             // Wolf's movement speed
    public bool isWolfLeaving;          // Finished eating, eating other sheeps later, cya!
    public GameObject wolfLeaveLocation;

    private Vector3 targetPosXYZ;
    private GameObject sheepChild;
    SpriteRenderer sheepChildRenderer;


    private void Start()
    {
        //sheepChild = transform.GetChild(0).gameObject;
        //sheepChildRenderer = sheepChild.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update ()
    {
        if (wolfLeaveLocation == null) wolfLeaveLocation = GameObject.Find("WolfLeaveLocation");
        

        targetPosXYZ = new Vector3(targetSheepPos.x, targetSheepPos.y, this.transform.position.z);
   
        if (isWolfOnMove)
        {
            
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosXYZ, wolfSpeed);
            if (this.transform.position == targetPosXYZ )
            {
                //this.gameObject.transform.SetParent(targetSheepTrans);
                targetSheepTrans.SetParent(this.gameObject.transform);

                sheepChild = transform.GetChild(0).gameObject;
                sheepChildRenderer = GetComponent<SpriteRenderer>();
                sheepChildRenderer.enabled = false;
                isWolfLeaving = true;
            }

            if (isWolfLeaving)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, wolfLeaveLocation.transform.position, wolfSpeed);
                if (this.transform.position == wolfLeaveLocation.transform.position)
                {
                    Destroy(this.gameObject);
                }
                isWolfLeaving = false;
            }

        }


    }

    public void WolfStuff(Transform target)
    {
        isWolfOnMove = true;
        targetSheepTrans = target;
        targetSheepPos = target.position;
    }
}
