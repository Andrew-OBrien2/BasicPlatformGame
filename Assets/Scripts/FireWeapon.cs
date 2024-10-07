using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    //Drag and drop bullet prefab
    public GameObject bullet;
    //Drag ang drop tip of gun game object
    public Transform muzzle;

    //Calculated value
    private float timeBetweenShots;
    //Time between shots
    public float firingRate;
    //Bool to allow firing of gun.
    private bool canFire = true;

    private bool weaponEquipped = false;

    public AudioSource gunNoise;


    public void setWeaponEquipped(bool e)
    {
        weaponEquipped = e;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //If the timeBetweenShots is less than or equal to zero I can shoot my weapon
        if (timeBetweenShots <= 0)
        {
            //Reset timeBetweenShots to the specified firingRate
            timeBetweenShots = firingRate;
            //allow the player to fire their gun
            canFire = true;
        }
        else
        {
            //If the timeBetweenShots is not less than or equal to zero you cannot fire yet
            //i will deduct time from timeBetweenShots until it is 0 allowing the player
            //to shoot their weapon again.
            timeBetweenShots -= Time.deltaTime;
        }

        //If left mouse button is clicked
        if (Input.GetButtonDown("Fire1") && weaponEquipped)
        {
            if (canFire)
            {
                //After you fire you have to wait a specified amount of time 
                //to fire again so set the boolean to false.
                canFire = false;
                shootGun();
            }
        }
    }

    void shootGun()
    {
        //Instantiate the bullet at the position of the muzzle object given the players rotation
        Instantiate(bullet, muzzle.position, transform.rotation);

        gunNoise.Play();
    }
}
