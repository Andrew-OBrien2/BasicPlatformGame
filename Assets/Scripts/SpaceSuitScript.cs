using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpaceSuitScript : MonoBehaviour
{

    private bool isOnItem = false;
    private bool holdingItem = false;
    private Transform playerTransform;
    private GameObject playerGameObject;
    private Transform playerRightEye;
    private Transform playerRightEyePupil;

    private SpriteRenderer spriteRendererRightEye;
    private SpriteRenderer spriteRendererRightEyePupil;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnItem = true;
            playerTransform = collision.transform;
            playerGameObject = collision.gameObject;
            playerRightEye = playerTransform.Find("R_eye");
            playerRightEyePupil = playerTransform.Find("R_eye/R_pupil");
            spriteRendererRightEye = playerRightEye.GetComponent<SpriteRenderer>();
            spriteRendererRightEyePupil = playerRightEyePupil.GetComponent<SpriteRenderer>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the leaving object is tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnItem = false;
            //your error was below here:

            //playerTransform = null;
            //playerGameObject = null;
            //playerRightEye = null;
            //playerRightEyePupil = null;
            //spriteRendererRightEye = null;
            //spriteRendererRightEyePupil = null;
        }
    }
    private void Update() //EDIT HERE - IF THEY ARE ON IT AND NOT HOLDING IT, MAKE THEM HOLD IT. Otherwise *even if not on it* and they press E, drop item.
    {
        if (isOnItem && holdingItem == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {   
                {
                    PickUpItem();
                }
            }
        }
        else if (holdingItem)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DropItem();
            }
        }
    }
    private void PickUpItem()
    {
        if (playerTransform != null)
        {
            holdingItem = true;
            transform.SetParent(playerTransform);
            transform.localPosition = new Vector2(0, 0);

            if (spriteRendererRightEye != null)
            {
                spriteRendererRightEye.enabled = false;
            }
            if (spriteRendererRightEyePupil != null)
            {
                spriteRendererRightEyePupil.enabled = false;
            }
            Rigidbody2D playerRb = playerGameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.gravityScale = 1;
            }
        }
    }

    private void DropItem()
    {
        holdingItem = false;
        transform.SetParent(null); // Detach from player

        if (playerRightEye != null)
        {
            if (spriteRendererRightEye != null)
            {
                spriteRendererRightEye.enabled = true;
            }
        }
        if (playerRightEyePupil != null)
        {
            if (spriteRendererRightEyePupil != null)
            {
                spriteRendererRightEyePupil.enabled = true;
            }
        }

        Rigidbody2D playerRb = playerGameObject.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            playerRb.gravityScale = 2; // Adjust gravity scale as needed
        }

    }
}

