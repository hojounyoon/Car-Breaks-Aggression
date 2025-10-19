using UnityEngine;
using System.Collections;

public class PlayerCarController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float laneChangeSpeed = 15f;
    public float moveSpeed = 8f;

    [Header("Lane System")]
    public float[] lanePositions = { -2f, 0f, 2f };

    private int currentLane = 1;
    private bool isChangingLane = false;
    private Vector3 targetPosition;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(lanePositions[currentLane], transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleLaneMovement();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, moveSpeed);
    }

    void HandleInput()
    {
        if (isChangingLane) return;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0)
            {
                currentLane--;
                StartLaneChange();
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < lanePositions.Length - 1)
            {
                currentLane++;
                StartLaneChange();
            }
        }
    }

    void StartLaneChange()
    {
        isChangingLane = true;
        targetPosition = new Vector3(lanePositions[currentLane], transform.position.y, transform.position.z);
    }

    void HandleLaneMovement()
    {
        if (isChangingLane)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isChangingLane = false;
            }
        }
    }

    public int GetCurrentLane()
    {
        return currentLane;
    }
}
