using System;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileDamage;
    [SerializeField] private float projectileSpeed;

    [SerializeField] private float spawnCooldown;
    private float spawnCooldownTimer;

    private void Start()
    {
        ResetCooldownTimer();
    }

    private void Update()
    {
        if (GameStateManager.instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            spawnCooldownTimer -= Time.fixedDeltaTime;
            
            if (spawnCooldownTimer <= 0f)
            {
                SpawnProjectile();
                ResetCooldownTimer();
            }
        }
    }

    private void SpawnProjectile()
    {
        GameObject spawnedProjectile = Instantiate(projectile, projectileSpawnPoint.position,this.transform.rotation);
        spawnedProjectile.GetComponent<BasicProjectile>().SetUpProjectile(projectileDamage, projectileSpeed);
    }

    private void ResetCooldownTimer()
    {
        spawnCooldownTimer = spawnCooldown;
    }
}
