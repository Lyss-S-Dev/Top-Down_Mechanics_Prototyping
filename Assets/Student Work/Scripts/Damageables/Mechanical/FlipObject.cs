using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlipObject : MonoBehaviour
{
    private bool currentState;
    private Collider2D objectCollider;
    private Light2D objectLight;

    private void Awake()
    {
        objectCollider = GetComponent<Collider2D>();
        objectLight = GetComponentInChildren<Light2D>();
    }
    public void FlipState()
    {
        currentState = !currentState;
        ChangeProperties();
    }

    public void SetState(bool stateToSet)
    {
        currentState = stateToSet;
        ChangeProperties();
    }

    private void ChangeProperties()
    {
        if (currentState)
        {
            objectCollider.isTrigger = true;
            objectLight.intensity = 0f;
        }
        else
        {
            objectCollider.isTrigger = false;
            objectLight.intensity = 1f;
        }
    }
}
