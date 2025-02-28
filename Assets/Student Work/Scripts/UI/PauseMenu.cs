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
        gameStateManager = GameStateManager.Instance;

        if (gameStateManager != null)
        {
            gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
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
        ButtonSound();
        gameStateManager.ChangeGameState(GameStateManager.GameState.IN_GAME);
    }

    private void RestartButtonPressed()
    {
        ButtonSound();
        SceneLoader.Instance.RestartCurrentScene();
    }

    private void ReturnToMenuButtonPressed()
    {
        ButtonSound();
        gameStateManager.ChangeGameState(GameStateManager.GameState.CUTSCENE);
        SceneLoader.Instance.HandleLoadScene("Main Menu");
    }
    
}
    
