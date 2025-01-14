using System;
using UnityEngine;

public class InGameInterface : CanvasBaseFunctions
{
   

    private GameStateManager gameStateManager;
    
    void Start()
    {
        gameStateManager = GameStateManager.instance;

        if (gameStateManager != null)
        {
            gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
        }
        else
        {
            //Game State manager missing, error
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