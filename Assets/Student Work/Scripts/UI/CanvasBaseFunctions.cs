using System;
using UnityEngine;

public class CanvasBaseFunctions : MonoBehaviour
{

    private Canvas ownCanvas;

    private void Awake()
    {
        ownCanvas = this.GetComponent<Canvas>();
    }

    protected void Show()
    {
        if (ownCanvas)
        {
            ownCanvas.enabled = true;
        }
        
    }

    protected void Hide()
    {
        if (ownCanvas)
        {
            ownCanvas.enabled = false;
        }
        
    }
    
}
