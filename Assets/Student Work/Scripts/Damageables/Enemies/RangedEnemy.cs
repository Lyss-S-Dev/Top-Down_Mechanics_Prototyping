using System;
using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    private Animator rangedAnimator;

    private bool aimIsLocked = false;
    
    protected override void Start()
    {
        base.Start();
        rangedAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (GetCurrentState() == EnemyState.ACTIVE)
        {
            ActiveBehaviour();
            
        }

        if (GetCurrentState() != EnemyState.IDLE && !aimIsLocked)
        {
            FacePlayer();
        }
    }

    private void ActiveBehaviour()
    {
        //if far away from player and not already attacking, move away in a random direction
        //else, begin ranged attack
    }

    public void LockAim()
    {
        aimIsLocked = true;
    }

    private void UnlockAim()
    {
        aimIsLocked = false;
    }
    
    
}
