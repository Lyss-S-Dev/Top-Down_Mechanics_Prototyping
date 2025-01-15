
using System;
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

    [SerializeField] protected LayerMask detectionLayers;

    private EnemyState currentState;
    [SerializeField] protected SOEnemyStats statistics;

    private float currentHealth;

    protected Rigidbody2D enemyBody;

    protected virtual void Start()
    {
        currentHealth = statistics.maximumHealth;
        enemyBody = GetComponent<Rigidbody2D>();
        ChangeCurrentState(EnemyState.IDLE);
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

        if (currentState != EnemyState.ATTACK)
        {
            ChangeCurrentState(EnemyState.STUN);
            enemyBody.linearVelocity = Vector2.zero;
            StartCoroutine(StunCooldown());
            //Knockback if not attacking
            
        }
        
    }

    private void ChangeHealth(float modValue)
    {
        currentHealth -= modValue;
        if (currentHealth <= 0)
        {
            EnemyDeath();
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

    private IEnumerator StunCooldown()
    {
        yield return new WaitForSeconds(statistics.stunTime);
        ChangeCurrentState(EnemyState.ACTIVE);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, statistics.detectionRadius);
        Gizmos.DrawWireSphere(transform.position, statistics.attackRange);
    }
}
