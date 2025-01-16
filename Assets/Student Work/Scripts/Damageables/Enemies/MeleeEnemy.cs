
using System;
using System.Collections;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    private Transform playerPosition;
    private Animator meleeAnimator;
    [SerializeField] private Transform attackPoint;

    protected override void Start()
    {
        base.Start();
        meleeAnimator = GetComponent<Animator>();
        playerPosition = FindFirstObjectByType<PlayerHealth>().GetComponent<Transform>();
    }

    private void Update()
    {
        

        if (GetCurrentState() != EnemyState.STUN && GetCurrentState() != EnemyState.ATTACK)
        {
            DetectPlayer();
        }
            
        
    }

    private void FixedUpdate()
    {
        if (GetCurrentState() == EnemyState.ACTIVE)
        {
            ChasePlayer();
            FacePlayer();
        }

        if (GetCurrentState() == EnemyState.STUN || GetCurrentState() == EnemyState.ATTACK)
        {
            enemyBody.linearVelocity = Vector2.zero;
        }
    }

    private void DetectPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, statistics.detectionRadius, detectionLayers);
        foreach (Collider2D col in hits)
        {
            if (col.TryGetComponent(out PlayerHealth player) == true)
            {
                if (GetCurrentState() != EnemyState.ACTIVE)
                {
                    ChangeCurrentState(EnemyState.ACTIVE);
                }
            }
        }
    }

    private void ChasePlayer()
    {
        //move towards player
        //if within melee range, perform the attack
        
        if (Vector2.Distance(transform.position, playerPosition.position) <= statistics.attackRange)
        {
            AttackPlayer();
        }
        else
        {
            Vector2 direction = (playerPosition.position - transform.position).normalized;
            enemyBody.linearVelocity = direction * (statistics.movementSpeed * Time.fixedDeltaTime);
        }
    }

    private void AttackPlayer()
    {
        ChangeCurrentState(EnemyState.ATTACK);
        enemyBody.linearVelocity = Vector2.zero;
        meleeAnimator.SetTrigger("attackTrigger");
        
    }

    //enemy damage event goes here
    
    public void EndAttack()
    {
        ChangeCurrentState(EnemyState.ACTIVE);
    }
   
    
    private void FacePlayer()
    {
        transform.up = playerPosition.position - transform.position;
    }
    
    
}
