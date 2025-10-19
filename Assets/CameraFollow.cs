using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform playerTarget;

    [Header("Follow Settings")]
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("Bounds")]
    public bool useBounds = false;
    public float minY = -5f;
    public float maxY = 100f;

    void LateUpdate()
    {
        if (playerTarget == null)
        {
            Debug.LogWarning("CameraFollow: No player target assigned!");
            return;
        }

        Vector3 desiredPosition = playerTarget.position + offset;

        if (useBounds)
        {
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
