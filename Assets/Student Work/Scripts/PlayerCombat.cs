using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerAnimator playerAnimator;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = InputManager.Instance;
        playerAnimator = GetComponent<PlayerAnimator>();
        
        inputManager.AttackEvent += InputManagerOnAttackEvent;
    }

    private void InputManagerOnAttackEvent(object sender, EventArgs e)
    {
        if (!playerAnimator.IsAttackAnimationPlaying())
        {
            playerAnimator.PerformAttackAnimation();
        }
        
    }

    
}
