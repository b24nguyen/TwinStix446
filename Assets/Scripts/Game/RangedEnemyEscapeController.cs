using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyEscapeController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            transform.parent.GetComponent<RangedEnemyControl>().isRunning = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            transform.parent.GetComponent<RangedEnemyControl>().isRunning = false;
        }
    }
}
