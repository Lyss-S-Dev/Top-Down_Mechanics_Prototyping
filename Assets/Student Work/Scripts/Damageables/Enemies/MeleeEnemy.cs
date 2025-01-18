
using System;
using System.Collections;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    private Animator meleeAnimator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Vector3 attackBoxSize;
    
    
    protected override void Start()
    {
        base.Start();
        meleeAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (GetCurrentState() == EnemyState.ACTIVE)
        {
            ChasePlayer();
            FacePlayer();
        }
    }
    
    private void ChasePlayer()
    {
        
        //if within melee range, perform the attack
        //otherwise move towards the player
        
        if (Vector2.Distance(transform.position, playerPosition.position) <= statistics.attackRange && canAttack)
        {
            StartAttack();
        }
        else
        {
            Vector2 direction = (playerPosition.position - transform.position).normalized;
            enemyBody.linearVelocity = direction * (statistics.movementSpeed * Time.fixedDeltaTime);
        }
    }

    private void StartAttack()
    {
        //switch state to attack, stop moving and start the attack animation
        ChangeCurrentState(EnemyState.ATTACK);
        enemyBody.linearVelocity = Vector2.zero;
        enemyBody.bodyType = RigidbodyType2D.Kinematic;
        meleeAnimator.SetTrigger("attackTrigger");
        
    }

    public void HandleAttack()
    {
        //this method is called during the melee enemy attack via an animation event
        Collider2D[] targets = Physics2D.OverlapBoxAll(attackPoint.position, attackBoxSize, 0f, playerLayer);

        foreach (Collider2D col in targets)
        {
            if (col.gameObject.TryGetComponent(out IDamageable player))
            {
                player.TakeDamage(statistics.attackDamage);
            }
        }

        StartCoroutine(AttackCooldown());
    }
    
    
    
    public void EndAttack()
    {
        //this method is called at the end of the melee enemy attack via an animation event
        enemyBody.bodyType = RigidbodyType2D.Dynamic;
        ChangeCurrentState(EnemyState.ACTIVE);
    }
   
    
    

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.position, attackBoxSize);
    }
}
