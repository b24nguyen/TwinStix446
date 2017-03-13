using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime;                 // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    private ItemManager itemManager;        // Item Manager to pass to enemies

    void Start()
    {
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        GameObject newEnemy = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
        // Send over reference of the item drops manager to the enemy
        EnemyHealthManager enemyHealthManager = newEnemy.GetComponent<EnemyHealthManager>();
        enemyHealthManager.initGameObjects(itemManager);
    }
}