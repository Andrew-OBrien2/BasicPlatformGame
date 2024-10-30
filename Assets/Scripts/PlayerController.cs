using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //this is a variable for a rigidbody that is attached to the player
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    public float jumpForce;
    private float inputHorizontal;
    private int maxNumJumps;
    private int numJumps;
    public GameObject weaponHoldLocation;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {

        //I can only get this component using the following line of code
        //because the rigidobdy2d is attached to the player and this script is
        //also attached to the player
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        maxNumJumps = 1;
        numJumps = 1;
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

        if (inputHorizontal != 0)
        {
            playerAnimator.SetBool("isWalking", true);
            flipPlayerSprite(inputHorizontal);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

    private void flipPlayerSprite(float inputHorizontal)
    {
        if (inputHorizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputHorizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && numJumps <= maxNumJumps)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            numJumps++;
            playerAnimator.SetBool("isJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Grounded"))
        {
            numJumps = 1;
        }
        else if (collision.gameObject.CompareTag("Bat"))
        {
            SceneManager.LoadScene("Level01");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DoubleJump"))
        {
            maxNumJumps = 2;
            //Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("OB"))
        {
            //restart level
            SceneManager.LoadScene("Level01");
        }
        else if (collision.gameObject.CompareTag("Weapon"))
        {
            collision.gameObject.transform.SetParent(weaponHoldLocation.transform);
            //set the rotations of the weapon to match the player rotation
            collision.gameObject.transform.rotation = weaponHoldLocation.transform.rotation;
            //set location
            collision.gameObject.transform.position = weaponHoldLocation.transform.position;

            collision.gameObject.GetComponent<FireWeapon>().setWeaponEquipped(true);
        }
    }
}
