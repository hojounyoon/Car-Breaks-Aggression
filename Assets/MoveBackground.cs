using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public GameObject obstacleManager;
    public float scrollSpeed = -0.5f;
    private bool fear;
    private bool rage = false;
    private float timeCheck;
    private float timeInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeInterval = obstacleManager.GetComponent<ObstacleManager>().spawnInterval;
        timeCheck = Time.time + timeInterval;
        fear = obstacleManager.GetComponent<ObstacleManager>().fearMode;
        /*if (fear == true)
        {
            Debug.Log("Fear Mode");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (fear == false && Time.time >= timeCheck)
        {
            scrollSpeed -= .1f;
            timeCheck = Time.time + timeInterval;
            if (rage == false && scrollSpeed <= -1.5f)
            {
                transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
                Debug.Log("RAGE MODE UNLOCKED");
                rage = true;
            }
        }
        Vector2 offset = new Vector2(0, -1*(Time.time * scrollSpeed));
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
