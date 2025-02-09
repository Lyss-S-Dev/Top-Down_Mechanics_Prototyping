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

    protected override void FixedUpdate()
    {
        if (GameStateManager.Instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
             base.FixedUpdate();
             if (GetCurrentState() == EnemyState.ACTIVE)
             {
                 ChasePlayer();
                 FacePlayer();
             }
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

    protected void HandleAttack()
    {
        //this method is called during the melee enemy attack via an animation event
        Collider2D[] targets = Physics2D.OverlapBoxAll(attackPoint.position, attackBoxSize, 0f, playerLayer);

        foreach (Collider2D col in targets)
        {
            if (col.gameObject.TryGetComponent(out IDamageable player))
            {
                player.TakeDamage(statistics.attackDamage, this.transform.position);
            }
        }

        StartCoroutine(AttackCooldown());
    }
    
    
    
    protected void EndAttack()
    {
        //this method is called at the end of the melee enemy attack via an animation event
        enemyBody.bodyType = RigidbodyType2D.Dynamic;
        ChangeCurrentState(EnemyState.ACTIVE);
    }

    protected void PlayAttackAudio()
    {
        AudioPlayer.Instance.PlayClipAtPosition("Sword Attack");
    }
    

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.position, attackBoxSize);
    }
}
