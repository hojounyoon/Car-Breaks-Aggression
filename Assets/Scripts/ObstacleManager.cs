using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool fearMode;
    public float spawnInterval = 4f; 
    private Vector2 spawnAreaSize = new Vector2(24f, 24f);
    // Weighted spawn location possibilities
    private float[] enemyPositions = { -4.5f, -4.5f, -2.5f, -.5f, -.5f, 3.9f, 4f, 4f };
    private GameObject enemy;
    private float spawnCount = 0f;
    private float height = 0f;

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
            spawnCount++;
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Calculate a random position within the defined spawn area
        int randomX = Random.Range(0, enemyPositions.Count());

        if (spawnCount > 7 && fearMode == false) {height = 20;}

        Vector3 spawnPosition = transform.position + new Vector3(enemyPositions[randomX], height, 0f); 

        enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.GetComponent<Obstacles>().isClone = true;
        enemy.GetComponent<Obstacles>().SetVelocity(spawnCount, fearMode);
    }

    // Optional: Visualize the spawn area in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, height, spawnAreaSize.y));
    }
}