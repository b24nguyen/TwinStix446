using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public bool paused;
    Canvas PauseMenuCanvas;

    // Use this for initialization
    void Start () {
        // Disable the pause menu
        PauseMenuCanvas = GameObject.Find("PauseMenu").GetComponent<Canvas>();
        PauseMenuCanvas.enabled = paused;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickPause()
    {
        paused = !paused;
        PauseMenuCanvas.enabled = paused;
        if (paused) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }

    public void ClickQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
