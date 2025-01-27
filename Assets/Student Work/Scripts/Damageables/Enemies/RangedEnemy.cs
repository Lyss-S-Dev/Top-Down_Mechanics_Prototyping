using System;
using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    private Animator rangedAnimator;

    private bool aimIsLocked;
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileSpeed;

    private LineRenderer aimLine;
    private bool aimLineIsActive;
    
    protected override void Start()
    {
        base.Start();
        rangedAnimator = GetComponent<Animator>();
        aimLine = GetComponent<LineRenderer>();
        HideAimLine();
    }

     protected override void FixedUpdate()
    {
        if (GameStateManager.instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
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
        
    }

    private void Update()
    {
        if (GameStateManager.instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            if (aimLineIsActive)
            {
                aimLine.SetPosition(1, new Vector3(0, projectileSpawnPoint.localPosition.y + statistics.detectionRadius, 0f));
            }
            else
            {
                aimLine.SetPosition(1, Vector3.zero);
            }
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
        ShowAimLine();
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

    protected void ShowAimLine()
    {
        aimLineIsActive = true;
    }
    protected void HideAimLine()
    {
        aimLineIsActive = false;
    }
}
