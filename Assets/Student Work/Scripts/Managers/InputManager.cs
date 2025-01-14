using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private PlayerActions inputActions;
    public event EventHandler AttackEvent;
    public event EventHandler PauseEvent;

    private Vector2 moveDirection;
    private Vector2 cursorPosition;
    private Vector3 cursorWorldPosition;

    private Camera mainCamera;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
         Destroy(this.gameObject);   
        }

        if (inputActions == null)
        {
            inputActions = new PlayerActions();
        }
        
        mainCamera = Camera.main;
        inputActions.INGAME.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        inputActions.INGAME.ATTACK.performed += ATTACKOnperformed;
        inputActions.INGAME.PAUSE.performed += PAUSEOnperformed;
    }

    private void OnDestroy()
    {
        inputActions.INGAME.ATTACK.performed -= ATTACKOnperformed;
        inputActions.INGAME.PAUSE.performed -= PAUSEOnperformed;
        inputActions.INGAME.Disable();
    }

    

    private void PAUSEOnperformed(InputAction.CallbackContext obj)
    {
        if (GameStateManager.instance != null)
        {
            if (GameStateManager.instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME ||
                GameStateManager.instance.GetCurrentGameState() == GameStateManager.GameState.PAUSED)
            {
                if (PauseEvent != null)
                {
                    PauseEvent.Invoke(this, EventArgs.Empty);
                }
                    
            }
            else
            {
                //do nothing
            }
        }
        
    }

    private void ATTACKOnperformed(InputAction.CallbackContext obj)
    {
        if (AttackEvent != null)
        {
            AttackEvent.Invoke(this, EventArgs.Empty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = inputActions.INGAME.MOVE.ReadValue<Vector2>();
        cursorPosition = inputActions.INGAME.LOOK.ReadValue<Vector2>();
        cursorWorldPosition = ConvertCursorToWorldPos();
        
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    private Vector3 ConvertCursorToWorldPos()
    {
        Vector3 cursorPositionWithZ = new Vector3(cursorPosition.x, cursorPosition.y, -mainCamera.transform.position.z);
        if (mainCamera)
        {
            return mainCamera.ScreenToWorldPoint(cursorPositionWithZ);
        }
        else
        {
            
            return Vector3.zero;
        }
    }

    public Vector3 GetCursorWorldPosition()
    {
        return cursorWorldPosition;
    }
}


