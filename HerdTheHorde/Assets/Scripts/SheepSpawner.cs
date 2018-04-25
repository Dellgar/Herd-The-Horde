using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour {

    private GameManager gmScript;

    public string[] spawnableRaces;         //List of spawnable sheep races
    private int listMin, listMax;           //Set the prefab restriction what to spawn, ie. white 0 - 2; inclusive - exclusive
    public GameObject[] spawnPrefabs;		//List of prefabs that can be spawned
    public GameObject[] spawnPoint;			//List of gameobjects storing the spawnpoint coordinate
	private int spawnPointIndex;			//Randomized value, pointing to what spawnpoint location is used

    public bool spawnerReady;
    public float spawningInterval;


    void Start ()
    {
        gmScript = GameObject.Find("_manager").GetComponent<GameManager>();
        spawnerReady = true;
        gmScript.spawnerActive = true;

        StartCoroutine(Spawning());
    }
	
	void Update ()
    {
        if(spawningInterval <= 0.5f) spawningInterval = 0.9f;

        for (int i = 0; i < 8; ++i)
        {
            if (Input.GetKeyDown("" + i))
            {
                GameObject nroSheep = Instantiate(spawnPrefabs[i],
                new Vector2(spawnPoint[spawnPointIndex].transform.position.x,
                spawnPoint[spawnPointIndex].transform.position.y), Quaternion.identity);

                nroSheep.name = "Sheep #" + gmScript.sheepSpawned.ToString();
            }
        }

	}

    IEnumerator Spawning()
    {
        while (gmScript.spawnerActive)
        {
            yield return new WaitForSeconds(spawningInterval);
            //choose a spawning point
            spawnPointIndex = Random.Range(0, spawnPoint.Length);

            //choose a race at random
            int rndRace = Random.Range(0, spawnableRaces.Length);
            
            switch (spawnableRaces[rndRace])
            {
                case "white":
                    listMin = 0;
                    listMax = 4;
                    //Debug.Log("race: white");
                    break;

                case "black":
                    listMin = 4;
                    listMax = 7;
                    //Debug.Log("race: black");
                    break;

                default:
                    Debug.Log("not of any race");
                    break;
            }

            //limit prefab pool to spawn only from one race
            int sheepPrefab = Random.Range(listMin, listMax);

            gmScript.SheepSpawn(1, spawnableRaces[rndRace]);

            GameObject sheep = Instantiate(spawnPrefabs[sheepPrefab],
                new Vector2(spawnPoint[spawnPointIndex].transform.position.x,
                spawnPoint[spawnPointIndex].transform.position.y), Quaternion.identity);
            sheep.name = "Sheep #" + gmScript.sheepSpawned.ToString();

            Debug.Log("Sheep Spawned");

            spawningInterval = spawningInterval - 0.1f;

        }
    }
}
