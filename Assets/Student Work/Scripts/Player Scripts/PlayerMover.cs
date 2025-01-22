using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private InputManager inputManager;
    private Rigidbody2D playerBody;

    private Vector2 direction;
    
    [SerializeField] private float moveSpeed;

    private bool isRunning;

    [SerializeField] private Transform cameraFollowTarget;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = InputManager.Instance;

        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = inputManager.GetMoveDirection();

        isRunning = playerBody.linearVelocity.magnitude > 0f;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        playerBody.linearVelocity = direction * (moveSpeed * Time.fixedDeltaTime);
    }

    public bool GetIsRunning()
    {
        return isRunning;
    }

    public Transform GetFollowTarget()
    {
        return cameraFollowTarget;
    }
}
