using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public GameObject obstacle;
    public float spawnRadius = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepearing("SpawnEnemy", 1f, 1f);   
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 randomPos = randomPos.insideUnitCircle * spawnRadius;

        randomPos += transform.position;
        randomPos.y = transform.position.y;

        Instantitate(obstacle, randomPos, Quarternion.identity);
    }
}
