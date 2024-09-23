using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    //timer to delay the spawn
    private float time;
    //timer delay
    public float delay;
    //keep track of an array of GameObjects
    //these GameObjects will be the position that the bat can spawn.
    public GameObject[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //add time to time
        //this will see how much time has passed since the last frame
        time += Time.deltaTime;

        //I only want to spawn a new bat if there was a specified amouint of time between the last time I spawned an object
        if(time >= delay)
        {
            spawnBat();
            time = 0f;
            //f because it is a float
        }
        
    }

    private void spawnBat()
    {
        //max number on Random.Range is exclusive (up to not including)
        int spawnNumber = Random.Range(0, spawnLocations.Length);
        //determine which object from the array to spawn based off random spawnNum
        GameObject spawnLocation = spawnLocations[spawnNumber];
        //spawn the bat
        Instantiate(spawnObject);
        spawnObject.transform.position = new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y);
    }
}
