using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : CanvasBaseFunctions
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private GameStateManager gameStateManager;

    [SerializeField] private Button restartButton;
    [SerializeField] private Button returnToMenuButton;

    private Animator animator;
    
    void Start()
    {
        gameStateManager = GameStateManager.Instance;

        if (gameStateManager != null)
        {
            gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
        }
        
        animator = GetComponent<Animator>();
        
        restartButton.onClick.AddListener(RestartButtonPressed);
        returnToMenuButton.onClick.AddListener(ReturnToMenuButtonPressed);
        
        Hide();
    }

    private void GameStateManagerOnStateHasChanged(object sender, EventArgs e)
    {
        if (gameStateManager.GetCurrentGameState() == GameStateManager.GameState.GAME_OVER)
        {
            Show();
            animator.SetTrigger("Death");
        }
    }

    private void RestartButtonPressed()
    {
        ButtonSound();
        SceneLoader.Instance.RestartCurrentScene();
    }

    private void ReturnToMenuButtonPressed()
    {
        ButtonSound();
        SceneLoader.Instance.HandleLoadScene("Main Menu");
    }
}
