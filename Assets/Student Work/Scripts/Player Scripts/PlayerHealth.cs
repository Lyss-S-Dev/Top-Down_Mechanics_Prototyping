using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable

{

    public event EventHandler PlayerTookDamage;
    
    private const float playerMaxHealth = 6;
    private float playerCurrentHealth;

    private PlayerStateManager playerStateManager;

    private void Awake()
    {
        playerStateManager = GetComponent<PlayerStateManager>();
        playerCurrentHealth = playerMaxHealth;
    }

    public void TakeDamage(float damageValue)
    {
        if (playerStateManager.GetCurrentPlayerState() == PlayerStateManager.PlayerState.NORMAL)
        {
            ReduceHealth(damageValue);
        }
        
    }
    public void TakeDamage(float damageValue, Transform damageSource)
    {
        if (playerStateManager.GetCurrentPlayerState() == PlayerStateManager.PlayerState.NORMAL)
        {
            ReduceHealth(damageValue);
        }
    }

    private void ReduceHealth(float modValue)
    {
        playerCurrentHealth -= modValue;
        PlayerTookDamage.Invoke(this,EventArgs.Empty);

        if (playerCurrentHealth > 0)
        {
            playerStateManager.ChangePlayerState(PlayerStateManager.PlayerState.INVINCIBLE);
        }
        else
        {
            playerStateManager.ChangePlayerState(PlayerStateManager.PlayerState.DEAD);
        }
        
    }
    
    public float GetPlayerHealth()
    {
        return playerCurrentHealth;
    }
    
    
}
