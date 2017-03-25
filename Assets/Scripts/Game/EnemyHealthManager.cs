using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int health;
    public int scoreCount;
    private GameController scoreBoardController;
    private ItemManager itemManager;

    // Use this for initialization
    void Start ()
    {
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

    // Pass references so that we don't have to find objects for every created enemy
    public void initGameObjects(ItemManager itemManagerRef)
    {
        itemManager = itemManagerRef;
    }

    // Update is called once per frame
    void Update ()
    {
		if (health <= 0)
        {
            // Updating score once enemy dies
            Destroy(gameObject);
            scoreBoardController.addScore(scoreCount);
            itemManager.DropItem(this.name, this.transform.position);
        }
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Kill()
    {
        health = 0;
    }
}
