using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VictoryUI : CanvasBaseFunctions
{
    private GameStateManager gameStateManager;
    
    [SerializeField] private Button returnToMenuButton;
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI comboText;
    
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
        
        returnToMenuButton.onClick.AddListener(ReturnToMenuButtonPressed);
        tryAgainButton.onClick.AddListener(TryAgainButtonPressed);
        
        Hide();
    }

    private void GameStateManagerOnStateHasChanged(object sender, EventArgs e)
    {
        if (gameStateManager.GetCurrentGameState() == GameStateManager.GameState.END_OF_LEVEL)
        {
            Show();
            SetScoreText();
            SetComboText();
        }
    }

    private void SetScoreText()
    {
        scoreText.text = string.Format("Score: " + "{0:000000}", ScoringManager.instance.GetPlayerScore());
    }

    private void SetComboText()
    {
        comboText.text = string.Format("Highest Combo: " + "{0:000}", ScoringManager.instance.GetHighestComboCount());
    }

    private void ReturnToMenuButtonPressed()
    {
        SceneLoader.instance.HandleLoadScene("Main Menu");
    }

    private void TryAgainButtonPressed()
    {
        SceneLoader.instance.RestartCurrentScene();
    }
}
