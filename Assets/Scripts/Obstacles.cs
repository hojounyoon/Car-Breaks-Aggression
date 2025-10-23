using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float obstacleVelocity = 15f;
    public bool isClone = false;
    private bool fear = false;
    //private float velocityScale = 1f;
    public GameObject player;
    public float despawnDelay = 5f;
    private float destroyTime;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        destroyTime = Time.time + despawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(0, obstacleVelocity);
        if (isClone == true && (transform.position.y > 50 || transform.position.y < -50))
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }

    public void SetVelocity(float velocityChange, bool fearMode)
    {
        fear = fearMode;
        if (fear == false)
        {
            if (velocityChange <= 10f)
            {
                obstacleVelocity -= velocityChange;
            }
            else
            {
                obstacleVelocity = 5f - velocityChange;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (fear == true || obstacleVelocity > 1f)
            {
                Debug.Log("Collided - Game Over");
                Destroy(this.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy Eviscerated (+1 Aggression Point)");
            }
        }
        
    }
}
