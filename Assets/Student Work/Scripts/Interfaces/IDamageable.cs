using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damageValue); 
    void TakeDamage(float damageValue, Transform damageSource);
}
