using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    private Light2D objectLight;
    [SerializeField] private float minimumIntensity = 0.5f;
    [SerializeField] private float maximumIntensity = 2.0f;

    [SerializeField] private float minFlickerTime = 0.1f;
    [SerializeField] private float maxFlickerTime = 0.3f;
    
    void Start()
    {
        objectLight = GetComponentInChildren<Light2D>();
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            objectLight.intensity = Random.Range(minimumIntensity, maximumIntensity);
            yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
        }
    }
    
}
