using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
    GameObject player;
    PlayerHealthManager playerHealthManager;
    Canvas GameOverMenuCanvas;

    // Use this for initialization
    void Start () {
        // Disable the gameover menu
        GameOverMenuCanvas = GameObject.Find("GameOverMenu").GetComponent<Canvas>();
        GameOverMenuCanvas.enabled = false;
        // Get reference to player health
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthManager = player.GetComponent<PlayerHealthManager>();
    }
	
	// Update is called once per frame
	void Update () {
        // If the player is dead
		if (playerHealthManager.health == 0)
        {
            // Pause the game and display the gameover menu
            Time.timeScale = 0;
            GameOverMenuCanvas.enabled = true;
        }
	}

    public void ClickMainMenu()
    {
        // Restore regular timescale
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
