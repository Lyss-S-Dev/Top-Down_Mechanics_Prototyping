using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private InputManager inputManager;
    private Rigidbody2D playerBody;

    private Vector2 direction;
    
    [SerializeField] private float moveSpeed;
    
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
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        playerBody.linearVelocity = direction * (moveSpeed * Time.fixedDeltaTime);
    }
}
