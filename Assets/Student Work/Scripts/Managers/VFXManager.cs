using System.Collections;
using Unity.Mathematics;
using UnityEngine;
public class VFXManager : MonoBehaviour
{
   
    public static VFXManager Instance;

    [SerializeField] private GameObject alertParticle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    /// <summary>
    /// Begins a coroutine that causes the passed sprite to tint red for a moment
    /// </summary>
    /// <param name="spriteToFlash">The sprite of the object that has taken damage</param>
    public void DamageFlash(SpriteRenderer spriteToFlash)
    {
        if (spriteToFlash != null)
        {
            Color originalColour = spriteToFlash.color;
            StartCoroutine(DamageFlashDuration(spriteToFlash, originalColour));
        }
        
    }

    /// <summary>
    /// Spawns the Alert particle system at a given position. Used by enemies to indicate they have spotted the player
    /// </summary>
    /// <param name="worldPosition">The position of the object</param>
    public void SpawnAlertParticle(Vector3 worldPosition)
    {
        Instantiate(alertParticle, worldPosition, quaternion.identity);
    }

    private IEnumerator DamageFlashDuration(SpriteRenderer flashingSprite, Color originalColour)
    {
        flashingSprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        flashingSprite.color = originalColour;
    }
}
