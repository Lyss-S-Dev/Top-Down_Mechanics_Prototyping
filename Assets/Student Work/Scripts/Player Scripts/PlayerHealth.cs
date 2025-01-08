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
            ModifyHealth(damageValue);
        }
        
    }
    public void TakeDamage(float damageValue, Transform damageSource)
    {
        if (playerStateManager.GetCurrentPlayerState() == PlayerStateManager.PlayerState.NORMAL)
        {
            ModifyHealth(damageValue);
        }
    }

    private void ModifyHealth(float modValue)
    {
        playerCurrentHealth -= modValue;
        PlayerTookDamage.Invoke(this, EventArgs.Empty);
    }
    
    public float GetPlayerHealth()
    {
        return playerCurrentHealth;
    }
    
    
}
