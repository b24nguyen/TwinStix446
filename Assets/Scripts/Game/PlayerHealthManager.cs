using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int health;
    public int maxPlayerHealth;
    
    // Use this for initialization
	void Start ()
    {
        health = maxPlayerHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health > maxPlayerHealth) health = maxPlayerHealth;
	}

    public void HurtPlayer(int damage)
    {
        health -= damage;
        if (health <= 0) health = 0;
    }
}
