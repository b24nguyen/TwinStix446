using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    public Transform target;
    public int damage;
    public float speed = 3;

    // Initialise enemy stats and elements
    void Start ()
    {
        target = GameObject.Find("Player").transform;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthManager playerHealthManager = other.GetComponent<PlayerHealthManager>();
            if (playerHealthManager.GetPowerMode())
            {
                // Enemy dies if in power mode
                this.GetComponent<EnemyHealthManager>().health = 0;
            } else
            {
                playerHealthManager.HurtPlayer(damage);
                other.GetComponent<PlayerControl>().ApplyKnockback(transform.position);
            }
            
        }
    }
}
