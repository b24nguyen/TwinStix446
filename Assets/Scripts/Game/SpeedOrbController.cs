using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOrbController : OrbController {

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Update power mode state and destroy the orb
            other.GetComponent<PlayerControl>().FoundSpeedOrb();
            Destroy(gameObject);
        }
    }

}
