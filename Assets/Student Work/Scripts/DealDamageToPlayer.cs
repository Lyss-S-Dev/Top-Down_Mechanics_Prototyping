using System;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out IDamageable d))
        {
            d.TakeDamage(1f);
        }
    }
}
