using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    public GameObject[] spawnPrefabs;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)], new Vector2(Random.Range(1f, 4f), Random.Range(1f, 4f) ), Quaternion.identity);
        }
	}

}
