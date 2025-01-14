using System;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private InputManager inputManager;

    private Vector3 worldPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = InputManager.Instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        worldPosition = inputManager.GetCursorWorldPosition();
        
    }

    private void FixedUpdate()
    {
        if (GameStateManager.instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            transform.up = worldPosition  - this.transform.position;
            
        }
        
    }
}
