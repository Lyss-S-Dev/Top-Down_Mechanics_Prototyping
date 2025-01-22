using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public event EventHandler PlayerTookDamage;
    
    private const float playerMaxHealth = 6;
    private float playerCurrentHealth;

    private PlayerStateManager playerStateManager;

    [SerializeField] FollowTargetBehaviour followTarget;
    [SerializeField] private GameObject damageParticles;

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
            GameObject createdParticles = Instantiate(damageParticles, this.transform.position, quaternion.identity);
            createdParticles.transform.up = createdParticles.transform.position - damageSource.position;
        }
    }

    private void ReduceHealth(float modValue)
    {
        playerCurrentHealth -= modValue;
        VFXManager.Instance.DamageFlash(this.GetComponentInChildren<SpriteRenderer>());
        followTarget.Shake(0.2f);
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
