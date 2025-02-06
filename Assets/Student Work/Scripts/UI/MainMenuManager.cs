using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button levelSelectCloseButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button closeControlsButton;

    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject levelSelectPanel;
    
    private void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);
        levelSelectCloseButton.onClick.AddListener(HandleLevelSelectCloseButtonClicked);
        controlsButton.onClick.AddListener(HandleControlsButtonClicked);
        closeControlsButton.onClick.AddListener(HandleCloseControlsButtonClicked);
        exitButton.onClick.AddListener(HandleExitButtonClicked);
        
        controlsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
    }

    private void HandleStartButtonClicked()
    {
        levelSelectPanel.SetActive(true);
        ButtonAudio();
    }
    private void HandleLevelSelectCloseButtonClicked()
    {
        levelSelectPanel.SetActive(false);
        ButtonAudio();
    }
    private void HandleExitButtonClicked()
    {
        
        ButtonAudio();
        Application.Quit();
    }
    private void HandleControlsButtonClicked()
    {
        controlsPanel.SetActive(true);
        ButtonAudio();
    }

    private void HandleCloseControlsButtonClicked()
    {
        controlsPanel.SetActive(false);
        ButtonAudio();
    }

    private void ButtonAudio()
    {
        AudioPlayer.instance.PlayClipAtPosition("UI Button");
    }
}
