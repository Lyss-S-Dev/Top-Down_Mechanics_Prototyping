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
        gameStateManager = GameStateManager.instance;

        if (gameStateManager != null)
        {
            gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
        }
        else
        {
            //Game State Manager is missing, error
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
        SceneLoader.instance.RestartCurrentScene();
    }

    private void ReturnToMenuButtonPressed()
    {
        SceneLoader.instance.HandleLoadScene("Main Menu");
    }

}
