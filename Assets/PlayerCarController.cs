using UnityEngine;
using System.Collections;

public class PlayerCarController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float laneChangeSpeed = 15f;
    public float moveSpeed = 8f;

    [Header("Screen Boundaries")]
    public float leftBound = -2f;
    public float rightBound = 2f;
    public float bottomBound = -4f;
    public float topBound = 4f;

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

        CalculateLanePositions();
        transform.position = new Vector3(lanePositions[currentLane], transform.position.y, 0);
    }

    void CalculateLanePositions()
    {
        lanePositions = new float[3];
        lanePositions[0] = leftBound;
        lanePositions[1] = 0f;
        lanePositions[2] = rightBound;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleLaneMovement();
        ConstrainToScreen();
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
                transform.position = targetPosition;
            }
        }
    }

    void ConstrainToScreen()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
        pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
    }

    public int GetCurrentLane()
    {
        return currentLane;
    }
}
