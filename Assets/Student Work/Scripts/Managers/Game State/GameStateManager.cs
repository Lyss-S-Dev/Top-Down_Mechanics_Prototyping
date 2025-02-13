using System;
using UnityEngine;
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public event EventHandler StateHasChanged;

    private InputManager inputManager;
    
    public enum GameState
    {
        IN_GAME, //Player has full control and enemies act normally
        PAUSED, //Timescale is set to zero. No game actions take place
        GAME_OVER, //Player has died. Enemies stop acting. The game over screen will be displayed
        END_OF_LEVEL, //Player has reached the end of the level. Enemies stop acting. The victory screen will be displayed
        CUTSCENE, //Player and Enemies cannot act until the state changes to another state. Time is still set to normal scale
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

    /// <summary>
    /// Change the current state of the game to another value
    /// </summary>
    /// <param name="stateToChange">The state the game should transition into</param>
    public void ChangeGameState(GameState stateToChange)
    {
        currentGameState = stateToChange;
        if (StateHasChanged != null) StateHasChanged.Invoke(this, EventArgs.Empty);
    }

    
    /// <summary>
    /// Returns the current state of the game
    /// </summary>
    /// <returns></returns>
    public GameState GetCurrentGameState()
    {
        return currentGameState;
    }

    private void LevelStartSequence()
    {
        currentGameState = GameState.CUTSCENE;
    }
}
