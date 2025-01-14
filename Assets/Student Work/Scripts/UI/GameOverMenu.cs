using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : CanvasBaseFunctions
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private GameStateManager gameStateManager;

    private Button restartButton;
    private Button returnToMenuButton;
    
    void Start()
    {
        gameStateManager = GameStateManager.instance;

        if (gameStateManager != null)
        {
            gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
        }
        else
        {
            //Game State Manager is missing, error
        }
        
        Hide();
    }

    private void GameStateManagerOnStateHasChanged(object sender, EventArgs e)
    {
        if (gameStateManager.GetCurrentGameState() == GameStateManager.GameState.GAME_OVER)
        {
            Show();
        }
        
        
    }

}
