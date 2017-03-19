using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    Rigidbody2D body;

    public Transform target;
    public int damage;
    public float speed;

    public float stagger;
    public float staggerLength;
    private float staggerCount;
    private Vector2 staggerVec;

    // Initialise enemy stats and elements
    void Start ()
    {
        target = GameObject.Find("Player").transform;
        body = GetComponent<Rigidbody2D>();
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

            if (staggerCount <= 0)
            {
                // Move towards the target's current location
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                body.velocity = staggerVec;
                staggerCount -= Time.deltaTime;
            }
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

    public void ApplyStagger(Vector3 pos)
    {
        float staggerX, staggerY;

        staggerCount = staggerLength;

        if (pos.x < transform.position.x)
        {
            staggerX = stagger;
        }
        else
        {
            staggerX = -stagger;
        }

        if (pos.y < transform.position.y)
        {
            staggerY = stagger;
        }
        else
        {
            staggerY = -stagger;
        }

        staggerVec = new Vector2(staggerX, staggerY);
    }
}
