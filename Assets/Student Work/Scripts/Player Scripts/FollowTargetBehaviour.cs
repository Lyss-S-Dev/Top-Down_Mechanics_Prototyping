using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FollowTargetBehaviour : MonoBehaviour
{
    private Vector2 originalLocalPosition;
    
    private void Start()
    {
        originalLocalPosition = transform.localPosition;
    }
    
    public void Shake(float intensity)
    {
        if (GameStateManager.Instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME)
        {
            StartCoroutine(ShakeTime(originalLocalPosition, intensity));
        }
    }

    private IEnumerator ShakeTime(Vector2 originalPosition, float intensity)
    {
        float elapsedTime = 0f;
        float duration = 0.1f;

        while (elapsedTime < duration)
        {
            transform.localPosition = new Vector3(Random.Range(-1, 1) * intensity, Random.Range(-1, 1) * intensity, 0);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
