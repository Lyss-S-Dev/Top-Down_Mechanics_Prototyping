using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : CanvasBaseFunctions
{
    private GameStateManager gameStateManager;

    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button restartLevelButton;
    [SerializeField] private Button returnToMenuButton;
    
    private void Start()
    {
        gameStateManager = GameStateManager.instance;

        if (gameStateManager != null)
        {
            gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
        }
        else
        {
            //Game state manager missing, error
        }
        
        continueGameButton.onClick.AddListener(ContinueGame);
        restartLevelButton.onClick.AddListener(RestartButtonPressed);
        returnToMenuButton.onClick.AddListener(ReturnToMenuButtonPressed);
        
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

    private void RestartButtonPressed()
    {
        SceneLoader.instance.RestartCurrentScene();
    }

    private void ReturnToMenuButtonPressed()
    {
        SceneLoader.instance.HandleLoadScene("Main Menu");
    }
    
}
    
