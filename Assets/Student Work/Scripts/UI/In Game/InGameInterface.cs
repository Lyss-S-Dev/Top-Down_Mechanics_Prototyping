using System;
public class InGameInterface : CanvasBaseFunctions
{
    private GameStateManager gameStateManager;
    
    void Start()
    {
        gameStateManager = GameStateManager.Instance;

        if (gameStateManager != null)
        {
            gameStateManager.StateHasChanged += GameStateManagerOnStateHasChanged;
        }
        Hide();
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