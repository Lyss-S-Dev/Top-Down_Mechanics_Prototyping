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
        gameStateManager = GameStateManager.Instance;

        if (gameStateManager != null)
        {
            gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
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
        scoreText.text = string.Format("Score: " + "{0:000000}", ScoringManager.Instance.GetPlayerScore());
    }

    private void SetComboText()
    {
        comboText.text = string.Format("Highest Combo: " + "{0:000}", ScoringManager.Instance.GetHighestComboCount());
    }

    private void ReturnToMenuButtonPressed()
    {
        ButtonSound();
        SceneLoader.Instance.HandleLoadScene("Main Menu");
    }

    private void TryAgainButtonPressed()
    {
        ButtonSound();
        SceneLoader.Instance.RestartCurrentScene();
    }
}
