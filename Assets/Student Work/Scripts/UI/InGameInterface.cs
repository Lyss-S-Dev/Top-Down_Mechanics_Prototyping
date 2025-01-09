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
            //ERROR GOES HERE
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