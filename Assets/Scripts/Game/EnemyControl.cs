using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    public Transform target;
    public float speed = 3;

    // Initialise enemy stats and elements
    void Start ()
    {
		
	}

    // Used to handle all physics based events (e.g. movement)
    void FixedUpdate()
    {
        // Check that target is instantiated
        if (target)
        {
            // Get the vector to rotate towards the target
            Vector3 lookVec = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 4096);

            // Apply roation vector
            transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);

            // Move towards the target's current location
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    // Used to handle any other update events for the player
    void Update ()
    {

    }
}
