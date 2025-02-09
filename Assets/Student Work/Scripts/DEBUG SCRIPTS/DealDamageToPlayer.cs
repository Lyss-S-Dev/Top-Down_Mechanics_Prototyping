using UnityEngine;
public class DealDamageToPlayer : MonoBehaviour
{
    //This script is used in the test level to test the player health system
    //It is not present in the actual build of the game
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out IDamageable d))
        {
            d.TakeDamage(1f);
        }
    }
}
