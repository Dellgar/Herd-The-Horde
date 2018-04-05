using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    public GameObject[] spawnPrefabs;
    public GameObject[] spawnPoint;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)], 
                new Vector2(spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position.x, 
                spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position.y), Quaternion.identity);
        }
	}

}
