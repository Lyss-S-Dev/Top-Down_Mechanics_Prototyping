using System;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    private float projectileDamage;
    private float projectileSpeed;

    private Rigidbody2D projectileBody;

    private void Start()
    {
        projectileBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        TravelForwards();
    }

    private void TravelForwards()
    {
        projectileBody.linearVelocity = transform.up * (projectileSpeed * Time.fixedDeltaTime);
    }

    public void SetUpProjectile(float damageValue, float speedValue)
    {
        projectileDamage = damageValue;
        projectileSpeed = speedValue;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(projectileDamage, this.transform.position);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
