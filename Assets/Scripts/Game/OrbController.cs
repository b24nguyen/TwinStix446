using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour {
    const int TIME_TO_LIVE = 20;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, TIME_TO_LIVE);
    }
	
	// Update is called once per frame
	void Update () { }

    protected virtual void OnTriggerEnter2D(Collider2D other) { }

}
