using System;
using UnityEngine;

public class InGameInterface : CanvasBaseFunctions
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private GameStateManager gameStateManager;
    
    void Start()
    {
        gameStateManager = GameStateManager.instance;

        if (gameStateManager != null)
        {
            gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
        }
    }

    private void GameStateManagerOnStateHasChanged(object sender, EventArgs e)
    {
        if (gameStateManager.GetCurrentGameState() != GameStateManager.GameState.IN_GAME)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
}