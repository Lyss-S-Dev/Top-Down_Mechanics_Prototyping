using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI comboCounterText;
    [SerializeField] private Slider comboTimerSlider;
    [SerializeField] private RectTransform visualContainer;
    
    private void Hide()
    {
        visualContainer.gameObject.SetActive(false);
    }

    private void Show()
    {
        visualContainer.gameObject.SetActive(true);
    }

    private void Start()
    {
        ScoringManager.Instance.ComboHasUpdated += InstanceOnComboHasUpdated;
        ScoringManager.Instance.ComboHasEnded += InstanceOnComboHasEnded;
        Hide();
    }

    private void InstanceOnComboHasEnded(object sender, EventArgs e)
    {
        Hide();
    }

    private void InstanceOnComboHasUpdated(object sender, EventArgs e)
    {
        if (ScoringManager.Instance.GetIsComboActive())
        {
            Show();
        }
        
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        comboCounterText.text = string.Format("{0:00}", ScoringManager.Instance.GetActionComboCounter());
    }
    private void Update()
    {
        if (ScoringManager.Instance.GetIsComboActive())
        {
            comboTimerSlider.value = ScoringManager.Instance.GetComboTimeout();
        }
        
    }
}
