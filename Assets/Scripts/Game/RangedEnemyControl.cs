using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyControl : MonoBehaviour
{
    Rigidbody2D body;

    public Transform target;
    public float speed;

    public bool isPlayerInRange;
    public bool isRunning;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float shotCooldown;

    public float stagger;
    public float staggerLength;
    private float staggerCount;
    private Vector2 staggerVec;

    // Initialise enemy stats and elements
    void Start()
    {
        target = GameObject.Find("Player").transform;
        body = GetComponent<Rigidbody2D>();
        isPlayerInRange = false;
        isRunning = false;
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
            transform.rotation = Quaternion.LookRotation(-lookVec, Vector3.back);

            if (staggerCount <= 0)
            {
                //if (isRunning)                  // Player is closing in on enemy, run away!
                //{
                    //transform.position = Vector2.MoveTowards(-transform.position, -target.position, speed * Time.deltaTime);
                //}
                if (isPlayerInRange)       // Player is within range to shoot at, so shoot at them 
                {
                    if (Time.time > shotCooldown)       // Shoot at the player if able, otherwise stay still while reloading
                    {
                        // Delay between shots
                        shotCooldown = Time.time + fireRate;

                        // Create a shot object
                        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    }
                }
                else                            // Player is out of shooting range, move towards them 
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
            }
            else
            {
                body.velocity = staggerVec;
                staggerCount -= Time.deltaTime;
            }
        }
    }

    // Used to handle any other update events for the player
    void Update()
    {

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
