using System;
using TMPro;
using UnityEngine;

public class ScoreBarUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextBox;
    private Animator scoreBoxAnimator;
    void Start()
    {
        scoreBoxAnimator = GetComponent<Animator>();
        ScoringManager.Instance.ScoreHasUpdated += InstanceOnScoreHasUpdated;
        scoreTextBox.text = "000000";
    }

    private void InstanceOnScoreHasUpdated(object sender, EventArgs e)
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreBoxAnimator.SetTrigger("Scored");
        scoreTextBox.text = string.Format("{0:000000}", ScoringManager.Instance.GetPlayerScore());
    }
}
