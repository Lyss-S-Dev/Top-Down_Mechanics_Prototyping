using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable

{

    public event EventHandler PlayerTookDamage; 
    
    private const float playerMaxHealth = 6;
    private float playerCurrentHealth;

    private void Awake()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    private void Start()
    {
        
        
    }

    public void TakeDamage(float damageValue)
    {
        ModifyHealth(damageValue);
    }
    public void TakeDamage(float damageValue, Transform damageSource)
    {
       ModifyHealth(damageValue);
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
