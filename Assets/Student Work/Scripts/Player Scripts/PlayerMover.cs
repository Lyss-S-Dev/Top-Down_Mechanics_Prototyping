
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
        if (GameStateManager.instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            direction = inputManager.GetMoveDirection();
            
            isRunning = playerBody.linearVelocity.magnitude > 0f;
        }
        
    }

    private void FixedUpdate()
    {
        if (GameStateManager.instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            HandleMovement();
        }
        else
        {
            playerBody.linearVelocity = Vector2.zero;
        }
        
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
