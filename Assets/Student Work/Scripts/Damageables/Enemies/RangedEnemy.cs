using System;
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
        
    }

    protected void ShootProjectile()
    {
        GameObject spawnedProjectile = Instantiate(projectile, projectileSpawnPoint.position,this.transform.rotation);
        spawnedProjectile.GetComponent<BasicProjectile>().SetUpProjectile(statistics.attackDamage, projectileSpeed);
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
