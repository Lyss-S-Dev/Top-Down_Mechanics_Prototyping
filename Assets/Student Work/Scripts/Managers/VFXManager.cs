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
    
    public void DamageFlash(SpriteRenderer spriteToFlash)
    {
        if (spriteToFlash != null)
        {
            Color originalColour = spriteToFlash.color;
            StartCoroutine(DamageFlashDuration(spriteToFlash, originalColour));
        }
        
    }

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
