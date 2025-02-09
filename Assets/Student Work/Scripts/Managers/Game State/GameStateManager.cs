using System;
using UnityEngine;
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public event EventHandler StateHasChanged;

    private InputManager inputManager;
    
    public enum GameState
    {
        IN_GAME,
        PAUSED, 
        GAME_OVER,
        END_OF_LEVEL,
        CUTSCENE,
    }

    private GameState currentGameState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        inputManager = InputManager.Instance;
        inputManager.PauseEvent += InputManagerOnPauseEvent;

        LevelStartSequence();
    }

    private void InputManagerOnPauseEvent(object sender, EventArgs e)
    {
        if (currentGameState != GameState.PAUSED)
        {
            ChangeGameState(GameState.PAUSED);
        }
        else
        {
            ChangeGameState(GameState.IN_GAME);
        }
        
    }

    public void ChangeGameState(GameState stateToChange)
    {
        currentGameState = stateToChange;
        StateHasChanged.Invoke(this, EventArgs.Empty);
    }

    public GameState GetCurrentGameState()
    {
        return currentGameState;
    }

    private void LevelStartSequence()
    {
        currentGameState = GameState.CUTSCENE;
    }
}
