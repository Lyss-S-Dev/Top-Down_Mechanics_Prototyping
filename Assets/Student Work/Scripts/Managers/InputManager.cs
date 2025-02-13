using System;
using UnityEngine;
using UnityEngine.InputSystem;
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

        inputActions ??= new PlayerActions();
        
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
        //Must unsubscribe from these events and disable the input actions on loading a new scene to prevent errors and warnings
        inputActions.INGAME.ATTACK.performed -= ATTACKOnperformed;
        inputActions.INGAME.PAUSE.performed -= PAUSEOnperformed;
        inputActions.INGAME.Disable();
    }

    

    private void PAUSEOnperformed(InputAction.CallbackContext obj)
    {
        if (GameStateManager.Instance != null)
        {
            if (GameStateManager.Instance.GetCurrentGameState() == GameStateManager.GameState.IN_GAME ||
                GameStateManager.Instance.GetCurrentGameState() == GameStateManager.GameState.PAUSED)
            {
                if (PauseEvent != null)
                {
                    PauseEvent.Invoke(this, EventArgs.Empty);
                }
                    
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
    
    void Update()
    {
        moveDirection = inputActions.INGAME.MOVE.ReadValue<Vector2>();
        cursorPosition = inputActions.INGAME.LOOK.ReadValue<Vector2>();
        cursorWorldPosition = ConvertCursorToWorldPos();
    }

    /// <summary>
    /// Returns the normalized Vector2 to determine player direction
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    private Vector3 ConvertCursorToWorldPos()
    {
        //Manually assigning the z position to prevent it clipping into the camera
        Vector3 cursorPositionWithZ = new Vector3(cursorPosition.x, cursorPosition.y, -mainCamera.transform.position.z);
        if (mainCamera)
        {
            return mainCamera.ScreenToWorldPoint(cursorPositionWithZ);
        }

        return Vector3.zero;
    }

    /// <summary>
    /// Returns the Vector3 of the mouse position in world space
    /// </summary>
    /// <returns></returns>
    public Vector3 GetCursorWorldPosition()
    {
        return cursorWorldPosition;
    }
}


