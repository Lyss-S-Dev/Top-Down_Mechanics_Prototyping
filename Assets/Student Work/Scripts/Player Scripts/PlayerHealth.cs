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
        if (GameStateManager.Instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            playerCurrentHealth -= modValue;
                    
                    if (playerCurrentHealth > 0)
                    {
                        DamageFeedback();
                        playerStateManager.ChangePlayerState(PlayerStateManager.PlayerState.INVINCIBLE);
                    }
                    else
                    {
                        playerStateManager.ChangePlayerState(PlayerStateManager.PlayerState.DEAD);
                    }
        }
    }
    
    //Any visual or audio feedback that plays when the player takes damage is called here
    private void DamageFeedback()
    {
        
        AudioPlayer.Instance.PlayClipAtPosition("Player Hurt");
        ScoringManager.Instance.EndActionCombo();
        followTarget.Shake(0.3f);
        PlayerTookDamage.Invoke(this,EventArgs.Empty);
    }
    
    public float GetPlayerHealth()
    {
        return playerCurrentHealth;
    }

    public void PlayerDeathSequence()
    {
        AudioPlayer.Instance.PlayClipAtPosition("Player Death");
        spriteMask.eulerAngles = Vector3.zero;
        GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.CUTSCENE);
        GetComponent<PlayerAnimator>().PlayDeathAnimation();
    }

    
    //This method is called at the end of the death animation
    public void KillPlayer()
    {
        GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.GAME_OVER);
        Destroy(this.gameObject);
    }
    
}
