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

    [SerializeField] private Transform spriteMask;

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
    public void TakeDamage(float damageValue, Vector3 damageSource)
    {
        if (playerStateManager.GetCurrentPlayerState() == PlayerStateManager.PlayerState.NORMAL)
        {
            ReduceHealth(damageValue);
            GameObject createdParticles = Instantiate(damageParticles, this.transform.position, quaternion.identity);
            createdParticles.transform.up = createdParticles.transform.position - damageSource;
        }
    }

    private void ReduceHealth(float modValue)
    {
        playerCurrentHealth -= modValue;
        VFXManager.Instance.DamageFlash(this.GetComponentInChildren<SpriteRenderer>());
        ScoringManager.instance.EndActionCombo();
        followTarget.Shake(0.3f);
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

    public void PlayerDeathSequence()
    {
        spriteMask.eulerAngles = Vector3.zero;
        GameStateManager.instance.ChangeGameState(GameStateManager.GameState.CUTSCENE);
        GetComponent<PlayerAnimator>().PlayDeathAnimation();
    }

    public void KillPlayer()
    {
        GameStateManager.instance.ChangeGameState(GameStateManager.GameState.GAME_OVER);
        Destroy(this.gameObject);
    }
    
}
