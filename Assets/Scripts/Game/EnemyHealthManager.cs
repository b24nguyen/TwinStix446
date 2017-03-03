using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int health;
    public int scoreCount;
    private GameController scoreBoardController;

	// Use this for initialization
	void Start ()
    {
        health = 1;
        scoreCount = 10;
        // Looking for specific instance of GameController object
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            scoreBoardController = gameControllerObject.GetComponent <GameController>();
            
        }

        if (scoreBoardController == null)
        {
            Debug.Log("THERE WAS AN ERROR");
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
		if (health <= 0)
        {
            // Updating score once enemy dies
            Destroy(gameObject);
            scoreBoardController.addScore(scoreCount);
        }
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
