using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour {

    public GameObject[] spawnPrefabs;		//List of prefabs that can be spawned
    public GameObject[] spawnPoint;			//List of gameobjects storing the spawnpoint coordinate
	public int spawnPointIndex;				//Randomized value, pointing to what spawnpoint location is used

    public bool spawnerReady;
    public bool spawnerActive;
    public float spawningInterval;


	// Use this for initialization
	void Start () {
        spawnerReady = true;
        spawnerActive = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(spawnerActive && spawnerReady) StartCoroutine(Spawning());

        if(spawningInterval <= 1f) spawningInterval = 1f;
	}

    IEnumerator Spawning()
    {
        spawnerReady = false;
        yield return new WaitForSeconds(spawningInterval);

        spawnPointIndex = Random.Range(0, spawnPoint.Length);

        Instantiate(spawnPrefabs[Random.Range(0, 2)],
            new Vector2(spawnPoint[spawnPointIndex].transform.position.x,
            spawnPoint[spawnPointIndex].transform.position.y), Quaternion.identity);

        spawningInterval = spawningInterval - 0.1f;
        spawnerReady = true;
    }
}
