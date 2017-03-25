using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    public int health;
    public int maxPlayerHealth;
    private bool powerMode = false;

    public Sprite playerReg, playerPow;
    private SpriteRenderer spriteRenderer;
    private Slider healthSlider;
    private Text healthText;
    
    // Use this for initialization
	void Start ()
    {
        health = maxPlayerHealth;
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        healthText.text = "HP: " + health;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (health > maxPlayerHealth) health = maxPlayerHealth;
	}

    public bool GetPowerMode()
    {
        return powerMode;
    }

    public void HurtPlayer(int damage)
    {
        if (powerMode) { return; }

        health -= damage;
        if (health <= 0) health = 0;
        healthText.text =  "HP: " + health;
        // Set healthSlider.value to float within [0,1]
        healthSlider.value = System.Convert.ToSingle(health) / maxPlayerHealth;
    }

    public void FoundPowerOrb()
    {
        // If player finds another powerOrb before last one was disabled
        if (powerMode) { CancelInvoke("DisablePowerMode");  }
        powerMode = true;
        spriteRenderer.sprite = playerPow;

        // Disable the power orb in 10 seconds
        Invoke("DisablePowerMode", 10.0f);
    }

    void DisablePowerMode()
    {
        powerMode = false;
        spriteRenderer.sprite = playerReg;
    }
}
