using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private PlayerActions inputActions;

    public event EventHandler AttackEvent;

    private Vector2 moveDirection;
    private Vector2 cursorPosition;
    private Vector3 cursorWorldPosition;
    
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

        inputActions = new PlayerActions();
        inputActions.INGAME.Enable();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions.INGAME.ATTACK.performed += ATTACKOnperformed;
    }

    private void ATTACKOnperformed(InputAction.CallbackContext obj)
    {
        AttackEvent.Invoke(this,EventArgs.Empty);
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
        Vector3 cursorPositionWithZ = new Vector3(cursorPosition.x, cursorPosition.y, 10);
        return Camera.main.ScreenToWorldPoint(cursorPositionWithZ);
    }

    public Vector3 GetCursorWorldPosition()
    {
        return cursorWorldPosition;
    }
}


