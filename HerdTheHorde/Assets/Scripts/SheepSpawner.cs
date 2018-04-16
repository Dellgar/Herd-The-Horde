using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour {

    private GameManager gManagerScript;
    public GameObject[] spawnPrefabs;		//List of prefabs that can be spawned
    public GameObject[] spawnPoint;			//List of gameobjects storing the spawnpoint coordinate
	public int spawnPointIndex;				//Randomized value, pointing to what spawnpoint location is used

    public bool spawnerReady;
    //bool spawnerActive;
    public float spawningInterval;

	// Use this for initialization
	void Start ()
    {
        gManagerScript = GameObject.Find("_manager").GetComponent<GameManager>();
        spawnerReady = true;
        gManagerScript.spawnerActive = true;

        StartCoroutine(Spawning());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(spawningInterval <= 0.5f) spawningInterval = 0.9f;
	}

    IEnumerator Spawning()
    {
        while (gManagerScript.spawnerActive)
        {
            yield return new WaitForSeconds(spawningInterval);

            spawnPointIndex = Random.Range(0, spawnPoint.Length);

            Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)],
                new Vector2(spawnPoint[spawnPointIndex].transform.position.x,
                spawnPoint[spawnPointIndex].transform.position.y), Quaternion.identity);
            Debug.Log("Sheep Spawned");
            spawningInterval = spawningInterval - 0.1f;
            gManagerScript.SpawnedAmount(1);
        }
        
        
    }
}
