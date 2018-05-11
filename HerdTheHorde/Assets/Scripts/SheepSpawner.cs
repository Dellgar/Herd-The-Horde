using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour {

    private GameManager gmScript;

    public string[] spawnableRaces;         //List of spawnable sheep races
    private int listMin, listMax;           //Set the prefab restriction what to spawn, ie. white 0 - 2; inclusive - exclusive
    public GameObject[] spawnPrefabs;		//List of prefabs that can be spawned
    public Vector3[] spawnPoint;           //List of the spawnpoints

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
        if(spawningInterval <= 1f) spawningInterval = 1.8f;

        for (int i = 0; i < 9; ++i)
        {
            if (Input.GetKeyDown("" + i))
            {
                GameObject nroSheep = Instantiate(spawnPrefabs[i],
                new Vector2(spawnPoint[spawnPointIndex].x,
                spawnPoint[spawnPointIndex].y), Quaternion.identity);

                nroSheep.name = "Sheep Num#" + i.ToString();
            }
        }
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		foreach (var pos in spawnPoint)
		{
			Gizmos.DrawCube(pos, new Vector3(2f, 2f, 2f));
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
                    listMax = 1;
                    //Debug.Log("race: white");
                    break;

                case "black":
                    listMin = 5;
                    listMax = 6;
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
                new Vector2(spawnPoint[spawnPointIndex].x,
                spawnPoint[spawnPointIndex].y), Quaternion.identity);
            sheep.name = "Sheep #" + gmScript.sheepSpawned.ToString();

            Debug.Log("Sheep Spawned");

            spawningInterval = spawningInterval - 0.08f;

        }
    }
}
