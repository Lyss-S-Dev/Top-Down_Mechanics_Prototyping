using System.Collections;
using UnityEngine;


public class BaseEnemy : MonoBehaviour, IDamageable
{
    protected enum EnemyState
    {
        IDLE,
        ACTIVE,
        ATTACK,
        STUN,
        
    }

    protected Transform playerPosition;
    
    private EnemyState currentState;
    
    [SerializeField] protected LayerMask playerLayer;
    
    [SerializeField] protected SOEnemyStats statistics;
    private float currentHealth;

    protected Rigidbody2D enemyBody;

    protected bool canAttack = true;

    
    protected virtual void Start()
    {
        currentHealth = statistics.maximumHealth;
        enemyBody = GetComponent<Rigidbody2D>();
        playerPosition = FindFirstObjectByType<PlayerHealth>().GetComponent<Transform>();
        ChangeCurrentState(EnemyState.IDLE);
    }

    protected virtual void Update()
    {
        if (GetCurrentState() == EnemyState.IDLE)
        {
            DetectPlayer();
        }
    }

    protected void ChangeCurrentState(EnemyState stateToChange)
    {
        currentState = stateToChange;
    }

    public void TakeDamage(float damageValue)
    {
        ChangeHealth(damageValue);
    }

    public void TakeDamage(float damageValue, Transform damageSource)
    {
        ChangeHealth(damageValue);
        
        //if the enemy is not currently attacking, they become stunned momentarily
        if (currentState != EnemyState.ATTACK)
        {
            
            ChangeCurrentState(EnemyState.STUN);
            enemyBody.linearVelocity = Vector2.zero;
            enemyBody.bodyType = RigidbodyType2D.Kinematic;
            StartCoroutine(StunCooldown());
        }
    }

    private void ChangeHealth(float modValue)
    {
        currentHealth -= modValue;
        
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }
        else
        {
            VFXManager.Instance.DamageFlash(GetComponentInChildren<SpriteRenderer>());
        }
    }

    private void EnemyDeath()
    {
        Destroy(this.gameObject);
    }

    protected EnemyState GetCurrentState()
    {
        return currentState;
    }
    
    private void DetectPlayer()
    {
        //create an overlap circle
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, statistics.detectionRadius, playerLayer);
        foreach (Collider2D col in hits)
        {
            if (col.GetComponent<PlayerHealth>())
            {
                ChangeCurrentState(EnemyState.ACTIVE);
            }
        }
    }
    
    protected void FacePlayer()
    {
        transform.up = playerPosition.position - transform.position;
    }

    private IEnumerator StunCooldown()
    {
        yield return new WaitForSeconds(statistics.stunTime);
        enemyBody.bodyType = RigidbodyType2D.Dynamic;
        ChangeCurrentState(EnemyState.ACTIVE);
    }

    protected IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(statistics.attackCooldown);
        canAttack = true;
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, statistics.detectionRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, statistics.attackRange);
    }
}
