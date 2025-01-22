using System;
using Unity.Mathematics;
using UnityEngine;

public class BreakableObject : MonoBehaviour, IDamageable
{
       [SerializeField] private GameObject brokenObjectParticles;


       public void TakeDamage(float damageValue)
       {
           Destroy(this.gameObject);
       }
       
       public void TakeDamage(float damageValue, Vector3 damageSource)
       {
              if (brokenObjectParticles != null)
              {
                   GameObject createdParticles = Instantiate(brokenObjectParticles, transform.position, quaternion.identity);
                   createdParticles.transform.up = createdParticles.transform.position - damageSource;
              }
              
              Destroy(this.gameObject);
       }

       
}
