using System;
using System.Collections;
using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    private Animator rangedAnimator;

    private bool aimIsLocked = false;
    

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileSpeed;
    
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

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(statistics.attackCooldown);
        canAttack = true;
    }
    
}
