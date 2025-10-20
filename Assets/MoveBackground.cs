using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, -1*(Time.time * scrollSpeed));
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
