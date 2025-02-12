using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private Vector3 worldPosition;
    
    void Update()
    {
        worldPosition = InputManager.Instance.GetCursorWorldPosition();
    }

    private void FixedUpdate()
    {
        if (GameStateManager.Instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            transform.up = worldPosition  - this.transform.position;
        }
    }
}
