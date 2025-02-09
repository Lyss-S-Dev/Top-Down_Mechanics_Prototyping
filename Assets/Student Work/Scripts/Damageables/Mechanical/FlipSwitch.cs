using UnityEngine;
using UnityEngine.Rendering.Universal;
public class FlipSwitch : MonoBehaviour, IDamageable
{
    private SpriteRenderer switchSprite;
    private Light2D switchLights;

    private bool toggleState;

    [SerializeField] private FlipObject[] toggleFalseObjects;
    [SerializeField] private FlipObject[] toggleTrueObjects;

    [SerializeField] private Color toggleFalseColour;
    [SerializeField] private Color toggleTrueColour;   
    
    void Start()
    {
        switchSprite = GetComponentInChildren<SpriteRenderer>();
        switchLights = GetComponentInChildren<Light2D>();

        switchSprite.color = toggleFalseColour;
        switchLights.color = toggleFalseColour;

        SetUpFalseObjects();
        SetUpTrueObjects();
    }

    private void SetUpFalseObjects()
    {
        //Gives each sprite in the False Object array the same colour as the switches false state
        foreach (FlipObject falseObj in toggleFalseObjects)
        {
            falseObj.gameObject.GetComponentInChildren<SpriteRenderer>().color = toggleFalseColour;
            falseObj.gameObject.GetComponentInChildren<Light2D>().color = toggleFalseColour;
            falseObj.SetState(toggleState);
        }
    }

    private void SetUpTrueObjects()
    {
        //Gives each sprite in the True Object array the same colour as the switches true state
        foreach (FlipObject trueObj in toggleTrueObjects)
        {
            trueObj.gameObject.GetComponentInChildren<SpriteRenderer>().color = toggleTrueColour;
            trueObj.gameObject.GetComponentInChildren<Light2D>().color = toggleTrueColour;
            trueObj.SetState(!toggleState);
        }
    }

    public void TakeDamage(float damageValue)
    {
        ToggleSwitch();
    }

    public void TakeDamage(float damageValue, Vector3 damageSource)
    {
        ToggleSwitch();
    }
    
    private void ToggleSwitch()
    {
        toggleState = !toggleState;
        AudioPlayer.Instance.PlayClipAtPosition("Switch");

        if (toggleState)
        {
            switchSprite.color = toggleTrueColour;
            switchLights.color = toggleTrueColour;
        }
        else
        {
            switchSprite.color = toggleFalseColour;
            switchLights.color = toggleFalseColour;
        }
        ToggleObjects();
    }

    private void ToggleObjects()
    {
        foreach (FlipObject falseObj in toggleFalseObjects)
        {
            falseObj.FlipState();
        }

        foreach (FlipObject trueObj in toggleTrueObjects)
        {
            trueObj.FlipState();
        }
    }
}
