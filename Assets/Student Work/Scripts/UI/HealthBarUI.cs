using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HealthBarUI : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField] private RectTransform[] healthPips;
    private Animator healthBarAnimator;
    private void Start()
    {
        healthBarAnimator = GetComponent<Animator>();
        
        playerHealth = FindFirstObjectByType<PlayerHealth>().GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTookDamage += OnPlayerTookDamage;
        }
        UpdateHealthBar();
    }

    private void OnPlayerTookDamage(object sender, EventArgs e)
    {
        UpdateHealthBar();
        ShakeUIElement();
    }

    private void UpdateHealthBar()
    {
        float currentPlayerHealth = playerHealth.GetPlayerHealth();

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

    private void ShakeUIElement()
    {
        healthBarAnimator.SetTrigger("Shake");
    }

    
}
