using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField] private RectTransform[] healthPips;
    private Animator healthBarAnimator;

    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite brokenHeart;

    [SerializeField] private GameObject playerDamageFeedbackOverlay;
    
    private void Start()
    {
        healthBarAnimator = GetComponent<Animator>();
        
        playerHealth = FindFirstObjectByType<PlayerHealth>().GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTookDamage += OnPlayerTookDamage;
        }
        
        playerDamageFeedbackOverlay.SetActive(false);
        UpdateHealthBar();
    }

    private void OnPlayerTookDamage(object sender, EventArgs e)
    {
        UpdateHealthBar();
        ShakeUIElement();
        StartCoroutine(FlashDamageOverlay());
    }

    private void UpdateHealthBar()
    {
        float currentPlayerHealth = playerHealth.GetPlayerHealth();

        for (int i = 0; i < healthPips.Length; i++)
        {
            if (i <= (currentPlayerHealth - 1))
            {
                healthPips[i].GetComponent<Image>().sprite = fullHeart;
            }
            else
            {
                healthPips[i].GetComponent<Image>().sprite = brokenHeart;
            }
        }
    }

    private void ShakeUIElement()
    {
        healthBarAnimator.SetTrigger("Shake");
    }

    private IEnumerator FlashDamageOverlay()
    {
        playerDamageFeedbackOverlay.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        playerDamageFeedbackOverlay.SetActive(false);
    }
}
