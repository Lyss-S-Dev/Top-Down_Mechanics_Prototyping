using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button closeControlsButton;

    private Animator menuAnimator;
    
    private void Start()
    {
        menuAnimator = GetComponent<Animator>();
        
        startButton.onClick.AddListener(HandleStartButtonClicked);
        exitButton.onClick.AddListener(HandleExitButtonClicked);
        controlsButton.onClick.AddListener(HandleControlsButtonClicked);
        closeControlsButton.onClick.AddListener(handleCloseControlsButtonClicked);
    }

    private void HandleStartButtonClicked()
    {
        //call reference to scene loader
        //load first scene
        Debug.Log("START BUTTON PRESSED");
        SceneLoader.instance.HandleLoadScene("Level 1");
    }

    private void HandleExitButtonClicked()
    {
        Debug.Log("QUITTING APPLICATION");
        Application.Quit();
    }

    private void HandleControlsButtonClicked()
    {
        menuAnimator.SetTrigger("Show and Hide");
    }

    private void handleCloseControlsButtonClicked()
    {
        menuAnimator.SetTrigger("Show and Hide");
    }
}
