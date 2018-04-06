using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    public GameObject[] spawnPrefabs;		//List of prefabs that can be spawned
    public GameObject[] spawnPoint;			//List of gameobjects storing the spawnpoint coordinate
	public int spawnPointIndex;				//Randomized value, pointing to what spawnpoint location is used


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown(KeyCode.Space))
        {
			spawnPointIndex = Random.Range(0, spawnPoint.Length);

			Instantiate(spawnPrefabs[0], 
                new Vector2(spawnPoint[spawnPointIndex].transform.position.x,
				spawnPoint[spawnPointIndex].transform.position.y), Quaternion.identity);
        }
	}

}
