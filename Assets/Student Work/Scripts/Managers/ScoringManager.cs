using System;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{
    public static ScoringManager instance;
    public event EventHandler ScoreHasUpdated; 
    public event EventHandler ComboHasUpdated;
    public event EventHandler ComboHasEnded;
    
    private int playerScore;
    
    private int actionCounter;
    private bool isActionComboActive;
    private float actionComboTimeout;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        SetPlayerScore(0);
    }

    private void Update()
    {
        if (isActionComboActive && GameStateManager.instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            actionComboTimeout -= Time.deltaTime;
            if (actionComboTimeout <= 0)
            {
                EndActionCombo();
            }
        }
    }

    private void SetPlayerScore(int setPointsValue)
    {
        playerScore = setPointsValue;
    }

    public void UpdatePlayerScore(int pointsValue)
    {
        playerScore += pointsValue;
        ScoreHasUpdated.Invoke(this,EventArgs.Empty);
    }

    public void TickUpActionCounter()
    {
        if (actionCounter == 0)
        {
            isActionComboActive = true;
        }

        actionCounter++;
        ComboHasUpdated.Invoke(this.gameObject,EventArgs.Empty);
        ResetComboTimeout();
    }

    public void EndActionCombo()
    {
        isActionComboActive = false;
        ComboHasEnded.Invoke(this.gameObject,EventArgs.Empty);
        ResetActionCounter();
    }
    
    private void ResetActionCounter()
    {
        actionCounter = 0;
    }

    private void ResetComboTimeout()
    {
        actionComboTimeout = 2f;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public bool GetIsComboActive()
    {
        return isActionComboActive;
    }

    public int GetActionComboCounter()
    {
        return actionCounter;
    }

    public float GetComboTimeout()
    {
        return actionComboTimeout;
    }
}
