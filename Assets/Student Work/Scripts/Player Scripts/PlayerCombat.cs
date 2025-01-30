using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerAnimator playerAnimator;
    [SerializeField] private FollowTargetBehaviour followTarget;

    [SerializeField] private float playerDamage;
    
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Vector3 attackBoxSize;

    [SerializeField] private LayerMask ignoreLayers;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = InputManager.Instance;
        playerAnimator = GetComponent<PlayerAnimator>();
        
        inputManager.AttackEvent += InputManagerOnAttackEvent;
    }

    private void InputManagerOnAttackEvent(object sender, EventArgs e)
    {
        if (GameStateManager.instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            if (!playerAnimator.IsAttackAnimationPlaying())
            {
                playerAnimator.PerformAttackAnimation();
            }
        }
        
        
    }

    public void HandleAttack()
    {
        //draw overlap shape at attack point
        Collider2D[] targets = Physics2D.OverlapBoxAll(attackPoint.position, attackBoxSize, transform.rotation.z, ~ignoreLayers);
        
        foreach(Collider2D t in targets)
        {
            if (t.gameObject.TryGetComponent(out IDamageable d))
            {
                d.TakeDamage(playerDamage, this.transform.position);
                followTarget.Shake(0.11f);
                
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(attackPoint.position, attackBoxSize);
    }
    
}
