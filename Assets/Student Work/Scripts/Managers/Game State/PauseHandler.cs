using System;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    private GameStateManager gameStateManager;

    private void Start()
    {
        gameStateManager = GameStateManager.instance;
        
        gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
    }

    private void GameStateManagerOnStateHasChanged(object sender, EventArgs e)
    {
        if (gameStateManager.GetCurrentGameState() == GameStateManager.GameState.PAUSED)
        {
            PauseGame();
        }
        else
        {
            UnpauseGame();
        }
    }


    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
    }
}
