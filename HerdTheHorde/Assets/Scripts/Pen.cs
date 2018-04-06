using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pen : MonoBehaviour {

    List<Collider> collidedObj = new List<Collider>();
    public int sheepCount;
    public TextMesh penText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        penText.text = sheepCount.ToString();
		
	}

    void OnTriggerStay2D(Collider2D obj)
    {
        collidedObj.Add(obj.GetComponent<Collider>());
        Debug.Log("collided lol");
    }
}
