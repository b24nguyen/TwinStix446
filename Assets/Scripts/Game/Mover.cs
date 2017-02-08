using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed;
	
    // Sets the direction of the shots once they are created
	void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
	}
	
}
