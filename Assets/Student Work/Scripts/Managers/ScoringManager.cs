using System;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{
    public static ScoringManager instance;
    public event EventHandler ScoreHasUpdated;
    
    private int playerScore;
    
    private int actionCounter;
    private bool isActionComboActive;   
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
        
    }

    public void EndActionCombo()
    {
        
    }
    
    private void ResetActionCounter()
    {
        
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }
}
