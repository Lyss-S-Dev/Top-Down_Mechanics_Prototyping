using UnityEngine;

public interface IDamageable
{
    ///<summary>
    /// Assign damage to the object
    /// </summary>
    void TakeDamage(float damageValue); 
    
    /// <summary>
    /// Assign damage to the object with the context of the position of the damage source
    /// </summary>
    /// <param name="damageValue">The amount to reduce the enemy's health by</param>
    /// <param name="damageSource">The position of the damage dealer
    /// </param>
    void TakeDamage(float damageValue, Vector3 damageSource);
}
