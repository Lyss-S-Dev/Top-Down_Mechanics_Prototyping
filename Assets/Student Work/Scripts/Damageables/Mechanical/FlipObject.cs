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
    
    /// <summary>
    /// Invert the boolean state of the object
    /// </summary>
    public void FlipState()
    {
        currentState = !currentState;
        ChangeProperties();
    }

    /// <summary>
    /// Set the boolean state of the object
    /// </summary>
    /// <param name="stateToSet"> The state you want the object to have</param>
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
