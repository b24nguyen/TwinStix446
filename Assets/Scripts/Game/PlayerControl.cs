using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    Rigidbody2D body;
    public float speed = 5;
    public Vector2 moveVec;
    public Vector3 lookVec;

    // Required for the creation of bullet type objects
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Start ()
    {
        body = this.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
    {
        moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal_Movement"), CrossPlatformInputManager.GetAxis("Vertical_Movement")) * speed;
        lookVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal_Aiming"), CrossPlatformInputManager.GetAxis("Vertical_Aiming"), 4096);

        //body.AddForce(moveVec);
        if (lookVec.x != 0 && lookVec.y != 0)
            transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);
        body.velocity = moveVec;
	}

    public void Update()
    {
        // Checking if the right stick is moving in order to shoot
        if (lookVec.x != 0 && lookVec.y != 0 && Time.time > nextFire)
        {
            // Delay between shots
            nextFire = Time.time + fireRate;
            // Create a shot object
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
