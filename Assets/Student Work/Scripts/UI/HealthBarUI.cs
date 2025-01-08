using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private PlayerHealth playerHealth;

    [SerializeField] private RectTransform[] healthPips;

    [SerializeField] private TextMeshProUGUI healthText;
    
    private 
    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>().GetComponent<PlayerHealth>();
        playerHealth.PlayerTookDamage += OnPlayerTookDamage;
        
        UpdateHealthBar();
    }

    private void OnPlayerTookDamage(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float currentPlayerHealth = playerHealth.GetPlayerHealth();
        healthText.text = playerHealth.GetPlayerHealth().ToString(); 

        for (int i = 0; i < healthPips.Length; i++)
        {
            if (i <= (currentPlayerHealth - 1))
            {
                healthPips[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                healthPips[i].GetComponent<Image>().enabled = false;
            }
        }
    }
}
