using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    // TODO: different arrays for items status (e.g. goodItems, okayItems, greatItems)
    public GameObject[] items; // Stores all items

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Instantiate item based on enemyType and position
    public void DropItem(string enemyType, Vector3 position)
    {
        if (enemyType.Contains("BasicEnemy"))
        {
            // 90% Chance a BasicEnemy does not spawn item
            if (Random.Range(0, 10) > 1) { return; }
            // TODO: reduce range to worse items rather than all items
            int itemIndex = Mathf.FloorToInt(Random.Range(0, items.Length));
            Instantiate(items[itemIndex], position, Quaternion.identity);
        } else
        {
            // Default Case
            Debug.Log("ERROR: invalid enemyType " + enemyType);
        }
    }
}
