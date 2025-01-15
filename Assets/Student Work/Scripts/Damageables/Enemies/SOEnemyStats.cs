using UnityEngine;

[CreateAssetMenu(fileName = "SOEnemyStats", menuName = "Enemies/New Enemy Stat Asset")]
public class SOEnemyStats : ScriptableObject
{
    [Header("Health")] 
    public float maximumHealth;
    public float stunTime;
    
    [Space(10)]
    [Header("Movement")] 
    public float movementSpeed;

    [Space(10)] 
    [Header("Detection")] 
    public float detectionRadius;

    [Space(10)] 
    [Header("Attack")] 
    public float attackRange;
    public float attackDamage;
}
