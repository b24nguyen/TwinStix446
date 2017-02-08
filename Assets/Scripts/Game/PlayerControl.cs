using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    Rigidbody2D body;
    public float speed = 5;

	void Start ()
    {
        body = this.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal_Movement"), CrossPlatformInputManager.GetAxis("Vertical_Movement")) * speed;
        Vector3 lookVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal_Aiming"), CrossPlatformInputManager.GetAxis("Vertical_Aiming"), 4096);

        //body.AddForce(moveVec);
        if (lookVec.x != 0 && lookVec.y != 0)
            transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);
        body.velocity = moveVec;
	}
}
