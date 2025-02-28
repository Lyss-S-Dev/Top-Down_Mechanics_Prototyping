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
        if (GameStateManager.Instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            TravelForwards();
        }
    }

    private void TravelForwards()
    {
        projectileBody.linearVelocity = transform.up * (projectileSpeed * Time.fixedDeltaTime);
    }

    
    /// <summary>
    /// Assign Speed and Damage values of a spawned projectile
    /// </summary>
    /// <param name="damageValue">The amount of damage the projectile does</param>
    /// <param name="speedValue">The speed of the projectile </param>
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
