using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrbIndicator : MonoBehaviour {

    public Color activeColour;
    public Color inactiveColour;

    UnityEngine.UI.Image image;

	// Use this for initialization
	void Start () {
        image = GetComponent<UnityEngine.UI.Image>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void activate()
    {
        image.color = activeColour;
    }

    public void deactivate()
    {
        image.color = inactiveColour; 
    }
}
