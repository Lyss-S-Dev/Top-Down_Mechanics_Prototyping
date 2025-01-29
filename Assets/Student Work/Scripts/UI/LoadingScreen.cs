using System;
using UnityEngine;

public class LoadingScreen : CanvasBaseFunctions
{
    private Animator loadingAnimator;
    
    private void Start()
    {
        loadingAnimator = GetComponent<Animator>();
        Hide();
    }

    public void ShowLoadingScreen()
    {
        Show();
        loadingAnimator.Play("Loading Hidden");
        loadingAnimator.SetTrigger("Show Loading");
    }

    public void HideLoadingScreen()
    {
        Hide();
    }
}
