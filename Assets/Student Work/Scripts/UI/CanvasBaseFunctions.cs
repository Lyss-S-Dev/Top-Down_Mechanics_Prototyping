using UnityEngine;
public class CanvasBaseFunctions : MonoBehaviour
{
    private Canvas ownCanvas;

    private void Awake()
    {
        ownCanvas = this.GetComponent<Canvas>();
    }

    
    /// <summary>
    /// Enables the canvas
    /// </summary>
    protected void Show()
    {
        if (ownCanvas)
        {
            ownCanvas.enabled = true;
        }
    }

    
    /// <summary>
    /// Disables the canvas
    /// </summary>
    protected void Hide()
    {
        if (ownCanvas)
        {
            ownCanvas.enabled = false;
        }
    }

    
    /// <summary>
    /// Play the button sound from the Audio Player
    /// </summary>
    protected void ButtonSound()
    {
        AudioPlayer.Instance.PlayClipAtPosition("UI Button");
    }
}
