using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float obstacleVelocity = 2f;
    private float velocityScale = 1f;
    public GameObject player;
    public float despawnDelay = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, despawnDelay);
        if (player.transform.position.y < this.transform.position.y)
        {
            velocityScale = -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(0, obstacleVelocity * velocityScale);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collided");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
