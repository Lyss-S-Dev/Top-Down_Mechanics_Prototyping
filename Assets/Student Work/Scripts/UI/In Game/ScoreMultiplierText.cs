using System;
using TMPro;
using UnityEngine;

public class ScoreMultiplierText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI multiplierTextBox;
    private Animator textAnimator;

    private bool isShownAndActive;
    private void Start()
    {
        textAnimator = GetComponent<Animator>();
        
        ScoringManager.instance.ComboHasUpdated += InstanceOnComboHasUpdated;
        ScoringManager.instance.ComboHasEnded += InstanceOnComboHasEnded;
        ScoringManager.instance.ScoreHasUpdated += InstanceOnScoreHasUpdated;
        
        HideText();
    }

    private void InstanceOnComboHasEnded(object sender, EventArgs e)
    {
        HideText();
    }

    private void InstanceOnScoreHasUpdated(object sender, EventArgs e)
    {
        if (isShownAndActive)
        {
            ScoreFlash();
        }
    }

    private void InstanceOnComboHasUpdated(object sender, EventArgs e)
    {
        CheckComboState();
    }

    private void ScoreFlash()
    {
        textAnimator.SetTrigger("Flash");
    }
    

    private void CheckComboState()
    {
        if (ScoringManager.instance.GetActionComboCounter() >= 16)
        {
            ShowText();
        }
        else
        {
            HideText();
        }
    }

    private void ShowText()
    {
        float scoreMultValue = ScoringManager.instance.GetCurrentScoreMult();
        if (scoreMultValue > 1)
        {
            multiplierTextBox.text = scoreMultValue + "X";
            isShownAndActive = true;
        }
        else
        {
            HideText();
        }
    }

    private void HideText()
    {
        multiplierTextBox.text = " ";
        isShownAndActive = false;
    }
}
