using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : CanvasBaseFunctions
{
    private GameStateManager gameStateManager;

    [SerializeField] private Button continueGameButton;
    
    private void Start()
    {
        gameStateManager = GameStateManager.instance;

        if (gameStateManager != null)
        {
            gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
        }
        
        continueGameButton.onClick.AddListener(ContinueGame);
        
        Hide();
    }

    private void GameStateManagerOnStateHasChanged(object sender, EventArgs e)
    {
        if (gameStateManager.GetCurrentGameState() == GameStateManager.GameState.PAUSED)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void ContinueGame()
    {
        gameStateManager.ChangeGameState(GameStateManager.GameState.IN_GAME);
    }
}
    
