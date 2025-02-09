using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private InputManager inputManager;

    private Vector3 worldPosition;
    
    void Start()
    {
        inputManager = InputManager.Instance;
        
    }
    
    void Update()
    {
        worldPosition = inputManager.GetCursorWorldPosition();
    }

    private void FixedUpdate()
    {
        if (GameStateManager.Instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            transform.up = worldPosition  - this.transform.position;
        }
    }
}
