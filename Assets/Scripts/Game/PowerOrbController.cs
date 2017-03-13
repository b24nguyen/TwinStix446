using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOrbController : MonoBehaviour {
    const int TIME_TO_LIVE = 20;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, TIME_TO_LIVE);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Update power mode state and destroy the orb
            other.GetComponent<PlayerHealthManager>().FoundPowerOrb();
            Destroy(gameObject);
        }
    }
}
