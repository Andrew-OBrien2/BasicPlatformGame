using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //this is a variable for a rigidbody that is attached to the player
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    public float jumpForce;
    private float inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        //I can only get this component using the following line of code
        //because the rigidobdy2d is attached to the player and this script is
        //also attached to the player
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //update is called once per frame.
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        //if the player pressed A move left, D move right
        //"Horizontal" is defined in the input section of the project settings
        //The line below will return:
        //0  - No button pressed
        //1  - Right arrow or D pressed
        //-1 - Left arrow or A pressed

        inputHorizontal = Input.GetAxisRaw("Horizontal");

        playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }
    }
}
