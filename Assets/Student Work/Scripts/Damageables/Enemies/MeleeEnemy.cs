
using System;
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
        Debug.Log("I AM IN THE" + GetCurrentState()+ " STATE");
        if (GetCurrentState() == EnemyState.IDLE)
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
    }

    private void DetectPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, statistics.detectionRadius, detectionLayers);
        foreach (Collider2D col in hits)
        {
            if (col.TryGetComponent(out PlayerHealth player) == true)
            {
                ChangeCurrentState(EnemyState.ACTIVE);
                
            }
        }
    }

    private void ChasePlayer()
    {
        //move towards player
        //if within melee range, switch to attack
        
        if (Vector2.Distance(transform.position, playerPosition.position) < statistics.attackRange)
        {
            ChangeCurrentState(EnemyState.ATTACK);
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
        enemyBody.linearVelocity = Vector2.zero;
        meleeAnimator.SetTrigger("attackTrigger");
        
    }
    
    
   
    
    private void FacePlayer()
    {
        transform.up = playerPosition.position - transform.position;
    }
    
    
}
