using System;
using Unity.Mathematics;
using UnityEngine;

public class BreakableObject : MonoBehaviour, IDamageable
{
       [SerializeField] private GameObject brokenObjectParticles;
       [SerializeField] private int scoreValue = 10;

       public void TakeDamage(float damageValue)
       {
           ObjectDestruction();
       }
       
       public void TakeDamage(float damageValue, Vector3 damageSource)
       {
              if (brokenObjectParticles != null)
              {
                   GameObject createdParticles = Instantiate(brokenObjectParticles, transform.position, quaternion.identity);
                   createdParticles.transform.up = createdParticles.transform.position - damageSource;
              }
              
              AudioPlayer.instance.PlayClipAtPosition("Object Broken" , transform.position, true);
              
              ObjectDestruction();
       }

       protected virtual void ObjectDestruction()
       {
           ScoringManager.instance.UpdatePlayerScore(scoreValue);
           ScoringManager.instance.TickUpActionCounter();
           Destroy(this.gameObject);
       }
       
}
