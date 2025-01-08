using UnityEngine;

public class CanvasBaseFunctions : MonoBehaviour
{
    protected void Show()
    {
        GetComponent<Canvas>().enabled = true;
    }

    protected void Hide()
    {
        GetComponent<Canvas>().enabled = false;
    }
    
}
