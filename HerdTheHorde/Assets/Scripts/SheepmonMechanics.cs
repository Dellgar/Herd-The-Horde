using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepmonMechanics : MonoBehaviour {

    string collidedwithtype;
    //string collidedwithrace;
    Vector3 rebirthpos;
    public GameObject[] whiteSheepTypes;
    public GameObject[] blackSheepTypes;
    GameObject prefabToSpawn;


    void OnCollisionEnter2D(Collision2D collisionWith)
    {
        //if we collide with gameobject that is tagged with SHEEP
        if (collisionWith.gameObject.tag == "sheep" && this.gameObject.tag == "sheepmon")
        {

            Debug.Log("Sheepmon collided with " + collisionWith.gameObject.name);

            rebirthpos = collisionWith.transform.position;

            collidedwithtype = collisionWith.gameObject.GetComponent<Sheep>().type;
            //collidedwithrace = collisionWith.gameObject.GetComponent<Sheep>().race;

            //if we collide with another sheep that is not of the same race
            //ie. if sheepmon is white then do this if collision happened with black, and vice versa
            if (collidedwithtype != this.gameObject.GetComponent<Sheep>().type)
            {

                //if sheepmon is black, then we spawn black
                if (this.gameObject.GetComponent<Sheep>().race == "black")
                {
                    if (collidedwithtype == "normal")
                    {
                        prefabToSpawn = blackSheepTypes[0];
                    }
                    if (collidedwithtype == "ton")
                    {
                        prefabToSpawn = blackSheepTypes[1];
                    }
                    if (collidedwithtype == "initial")
                    {
                        prefabToSpawn = blackSheepTypes[2];
                    }
                    if (collidedwithtype == "invisiwool")
                    {
                        prefabToSpawn = blackSheepTypes[3];
                    }
                    if (collidedwithtype == "rebaahl")
                    {
                        prefabToSpawn = blackSheepTypes[4];
                    }
                    if (collidedwithtype == "confuse")
                    {
                        prefabToSpawn = blackSheepTypes[5];
                    }

                }
                //if sheepmon is white, then we spawn white
                if (this.gameObject.GetComponent<Sheep>().race == "white")
                {
                    if (collidedwithtype == "normal")
                    {
                        prefabToSpawn = whiteSheepTypes[0];
                    }
                    if (collidedwithtype == "ton")
                    {
                        prefabToSpawn = whiteSheepTypes[1];
                    }
                    if (collidedwithtype == "initial")
                    {
                        prefabToSpawn = whiteSheepTypes[2];
                    }
                    if (collidedwithtype == "invisiwool")
                    {
                        prefabToSpawn = whiteSheepTypes[3];
                    }
                    if (collidedwithtype == "rebaahl")
                    {
                        prefabToSpawn = whiteSheepTypes[4];
                    }
                    if (collidedwithtype == "confuse")
                    {
                        prefabToSpawn = blackSheepTypes[5];
                    }
                }
            }

            //destroy the sheep we collided with and spawn a sheep of opposite race
            Destroy(collisionWith.gameObject);
            Instantiate(prefabToSpawn, rebirthpos, Quaternion.identity);
            
        }
    }
}
