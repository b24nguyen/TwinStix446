using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject basicEnemy;           // The basic enemy prefab to be spawned.
    public GameObject rangedEnemy;          // The ranged enemy prefab to be spawned.
    public float spawnTimeBasicEnemy;       // How long between each basic enemy spawn.
    public float spawnTimeRangedEnemy;      // How long between each ranged enemy spawn.
    public Transform[] spawnPointsBasic;    // An array of the spawn points basic enemies can spawn from.
    public Transform[] spawnPointsRanged;   // An array of the spawn points basic enemies can spawn from.
    private ItemManager itemManager;        // Item Manager to pass to enemies

    void Start()
    {
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("SpawnBasicEnemy", spawnTimeBasicEnemy, spawnTimeBasicEnemy);
        InvokeRepeating("SpawnRangedEnemy", spawnTimeRangedEnemy, spawnTimeRangedEnemy);
    }


    void SpawnBasicEnemy()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPointsBasic.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        GameObject newEnemy = Instantiate(basicEnemy, spawnPointsBasic[spawnPointIndex].position, spawnPointsBasic[spawnPointIndex].rotation) as GameObject;
        // Send over reference of the item drops manager to the enemy
        EnemyHealthManager enemyHealthManager = newEnemy.GetComponent<EnemyHealthManager>();
        enemyHealthManager.initGameObjects(itemManager);
    }

    void SpawnRangedEnemy()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPointsRanged.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        GameObject newEnemy = Instantiate(rangedEnemy, spawnPointsRanged[spawnPointIndex].position, spawnPointsRanged[spawnPointIndex].rotation) as GameObject;
        // Send over reference of the item drops manager to the enemy
        EnemyHealthManager enemyHealthManager = newEnemy.GetComponent<EnemyHealthManager>();
        enemyHealthManager.initGameObjects(itemManager);
    }
}