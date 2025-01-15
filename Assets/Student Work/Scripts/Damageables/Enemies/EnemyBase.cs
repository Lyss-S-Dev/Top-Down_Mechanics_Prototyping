using System;
using UnityEngine;

public class EnemyBase : EnemyBrain, IDamageable
{
    [SerializeField] private float maximumHealth;
    private float currentHealth;

    private IdleState idleState = new IdleState();
    
    private void Start()
    {
        currentHealth = maximumHealth;
        ChangeCurrentState(idleState);
    }

    public void TakeDamage(float damageValue)
    {
        
    }

    public void TakeDamage(float damageValue, Transform damageSource)
    {
        
    }
}
