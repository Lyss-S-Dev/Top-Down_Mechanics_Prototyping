
using System;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    private Transform playerPosition;
    
    private void DetectPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, statistics.detectionRadius, detectionLayers);
        foreach (Collider2D col in hits)
        {
            if (col.TryGetComponent(out PlayerHealth player) == true)
            {
                ChangeCurrentState(EnemyState.ACTIVE);
                playerPosition = col.GetComponent<Transform>();
            }
        }
    }

    private void ChasePlayer()
    {
        //move towards player
        //if within melee range, switch to attack
        if (Vector2.Distance(transform.position, playerPosition.position) > statistics.attackRange)
        {
            
        }
    }

    private void AttackPlayer()
    {
        //play animation
        //when it ends, return to active state
    }
    
    
    
}
