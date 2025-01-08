using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] protected float startingHealth = 10;
    private float currentHealth; 
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damageValue)
    {
        
    }
   
    public void TakeDamage(float damageValue, Transform damageSource)
    {
        ChangeHealth(damageValue);
    }

    private void ChangeHealth(float changeValue)
    {
        currentHealth -= changeValue;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

