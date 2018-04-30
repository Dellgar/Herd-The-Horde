using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {

    public string race;
    public string type;
    private GameManager gmScript;
    public Draggable draggableScript;
    public GameObject thisSheep;

    public Sprite bulgedSprite;
    private Sprite defaultSprite;

	// Use this for initialization
	void Start () {
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        draggableScript = GetComponent<Draggable>();

        defaultSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SheepBulge()
    {
        //thisSheep = cSheep;
        gmScript.SheepOnCursor(this.gameObject);

        if(!draggableScript.isMouseUp)  //on sheep click
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bulgedSprite;

        if(draggableScript.isMouseUp)   //on sheep release
            this.gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        //Instead, set animator controller to do this
    }
}
