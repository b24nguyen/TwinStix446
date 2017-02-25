using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    public int health;
    public int maxPlayerHealth;
    Slider healthSlider;
    
    // Use this for initialization
	void Start ()
    {
        health = maxPlayerHealth;
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
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
        // Set healthSlider.value to float within [0,1]
        healthSlider.value = System.Convert.ToSingle(health) / maxPlayerHealth;
    }
}
