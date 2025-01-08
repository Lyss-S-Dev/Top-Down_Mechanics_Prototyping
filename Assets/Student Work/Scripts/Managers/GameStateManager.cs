
using System;
using UnityEngine;


public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    
    public enum GameState
    {
        IN_GAME,
        PAUSED, 
        IN_MENU,
    }

    private GameState currentGameState = GameState.IN_GAME;

    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangeGameState(GameState stateToChange)
    {
        currentGameState = stateToChange;
    }

    public GameState GetCurrentGameState()
    {
        return currentGameState;
    }

}
