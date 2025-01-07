using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    
    private void Awake()
    {
        
    }

    private void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);
        exitButton.onClick.AddListener(HandleExitButtonClicked);
    }

    private void HandleStartButtonClicked()
    {
        //call reference to scene loader
        //load first scene
        Debug.Log("START BUTTON PRESSED");
        SceneLoader.instance.HandleLoadScene("Testing Scene");
    }

    private void HandleExitButtonClicked()
    {
        Debug.Log("QUITTING APPLICATION");
        Application.Quit();
    }
}
