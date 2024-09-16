using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //make the bat move towards the player
    public GameObject player;
    public Vector2 playerLocation;
    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);
    }
}
