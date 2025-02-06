using System.Collections;
using Unity.Mathematics;
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
    [SerializeField] protected LayerMask detectionIgnoreLayer;
    
    [SerializeField] protected SOEnemyStats statistics;
    private float currentHealth;

    protected Rigidbody2D enemyBody;

    protected bool canAttack = true;

    [SerializeField] private GameObject damageParticles;
    protected virtual void Start()
    {
        currentHealth = statistics.maximumHealth;
        enemyBody = GetComponent<Rigidbody2D>();
        playerPosition = FindFirstObjectByType<PlayerHealth>().GetComponent<Transform>();
        ChangeCurrentState(EnemyState.IDLE);
    }

    protected virtual void FixedUpdate()
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

    public void TakeDamage(float damageValue, Vector3 damageSource)
    {
        ChangeHealth(damageValue);
        EnemyDamageFeedback(damageSource);
        
        //if the enemy is not currently attacking, they become stunned momentarily
        if (currentState != EnemyState.ATTACK)
        {
            ChangeCurrentState(EnemyState.STUN);
            enemyBody.linearVelocity = Vector2.zero;
            enemyBody.bodyType = RigidbodyType2D.Kinematic;
            StartCoroutine(StunCooldown());
        }
    }

    private void EnemyDamageFeedback(Vector3 damageSource)
    {
        GameObject spawnedParticles = Instantiate(damageParticles, this.transform.position, quaternion.identity);
        spawnedParticles.transform.up = spawnedParticles.transform.position - damageSource;
        AudioPlayer.instance.PlayClipAtPosition("Took Damage");
        ScoringManager.instance.TickUpActionCounter();
    }

    private void ChangeHealth(float modValue)
    {
        currentHealth -= modValue;
        
        if (currentHealth <= 0)
        {
            ScoringManager.instance.UpdatePlayerScore(statistics.pointsValue);
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (playerPosition.position - transform.position).normalized, statistics.detectionRadius, ~detectionIgnoreLayer);
        if (hit)
        {
            if (hit.transform.GetComponent<PlayerHealth>())
            {
                VFXManager.Instance.SpawnAlertParticle(this.transform.position);
                AudioPlayer.instance.PlayClipAtPosition("Alert");
                ChangeCurrentState(EnemyState.ACTIVE);
            }
        }
    }
    
    protected void FacePlayer()
    {
        transform.up = playerPosition.position - transform.position;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
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
