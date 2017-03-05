using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void ClickHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
}
