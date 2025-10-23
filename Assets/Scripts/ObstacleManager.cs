using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnInterval = 1f; 
    public Vector2 spawnAreaSize = new Vector2(10f, 10f); 

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Calculate a random position within the defined spawn area
        float randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float randomZ = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

        Vector3 spawnPosition = transform.position + new Vector3(randomX, 0f, randomZ); 

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    // Optional: Visualize the spawn area in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, 0.1f, spawnAreaSize.y));
    }
}