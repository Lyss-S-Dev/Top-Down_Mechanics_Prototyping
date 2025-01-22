using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    private Animator rangedAnimator;

    private bool aimIsLocked;
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileSpeed;
    
    protected override void Start()
    {
        base.Start();
        rangedAnimator = GetComponent<Animator>();
    }

     protected override void FixedUpdate()
    { 
        base.FixedUpdate();
        
        if (GetCurrentState() == EnemyState.ACTIVE)
        {
            ActiveBehaviour();
        }

        if (GetCurrentState() != EnemyState.IDLE && !aimIsLocked)
        {
            FacePlayer();
        }

        enemyBody.linearVelocity = Vector2.zero;
    }

    private void ActiveBehaviour()
    {
        if (canAttack)
        {
            HandleAttack();
        }
    }

    private void HandleAttack()
    {
        canAttack = false;
        ChangeCurrentState(EnemyState.ATTACK);
        enemyBody.bodyType = RigidbodyType2D.Kinematic;
        rangedAnimator.SetTrigger("Attacking");
    }
    protected void ShootProjectile()
    {
        GameObject spawnedProjectile = Instantiate(projectile, projectileSpawnPoint.position,this.transform.rotation);
        spawnedProjectile.GetComponent<BasicProjectile>().SetUpProjectile(statistics.attackDamage, projectileSpeed);
    }

    protected void EndAttack()
    {
        ChangeCurrentState(EnemyState.ACTIVE);
        UnlockAim();
        enemyBody.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(AttackCooldown());
    }
    
    protected void LockAim()
    {
        aimIsLocked = true;
    }

    private void UnlockAim()
    {
        aimIsLocked = false;
    }
}
