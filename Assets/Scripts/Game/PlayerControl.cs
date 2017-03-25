using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    Rigidbody2D body;
    PlayerHealthManager playerHealthManager;

    public float speed = 5;
    public Vector2 moveVec;
    public Vector3 lookVec;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float shotCooldown;

    public float knockback;
    public float knockbackLength;
    private float knockbackCount;
    private Vector2 knockbackVec;

    // Initialise player stats and elements
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        playerHealthManager = GetComponent<PlayerHealthManager>();
	}

    // Used to handle all physics based events (e.g. movement)
	void FixedUpdate ()
    {
        // Get player movement vector from controls
        moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal_Movement"), CrossPlatformInputManager.GetAxis("Vertical_Movement")) * speed;

        // Get player rotation vector from controls
        lookVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal_Aiming"), CrossPlatformInputManager.GetAxis("Vertical_Aiming"), 4096);

        if (lookVec.x != 0 && lookVec.y != 0)
            transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);

        if (knockbackCount <= 0)
        {
            body.velocity = moveVec;
        }
        else
        {
            body.velocity = knockbackVec;
            knockbackCount -= Time.deltaTime;
        }
	}

    // Used to handle any other update events for the player
    public void Update()
    {
        // Checking if the right stick is moving in order to shoot
        if (lookVec.x != 0 && lookVec.y != 0 && Time.time > shotCooldown)
        {
            // Delay between shots
            shotCooldown = Time.time + fireRate;
            // Create a shot object
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    public void ApplyKnockback(Vector3 pos)
    {
        if (playerHealthManager.GetPowerMode()) { return; }

        float knockbackX, knockbackY;

        knockbackCount = knockbackLength;

        if (pos.x < transform.position.x)
        {
            knockbackX = knockback;
        }
        else
        {
            knockbackX = -knockback;
        }

        if (pos.y < transform.position.y)
        {
            knockbackY = knockback;
        }
        else
        {
            knockbackY = -knockback;
        }

        knockbackVec = new Vector2(knockbackX, knockbackY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && playerHealthManager.GetPowerMode())
        {
            other.GetComponent<EnemyHealthManager>().Kill();
        }
    }
}
