using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private InputManager inputManager;

    [SerializeField] Transform worldSpacePoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = InputManager.Instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        worldSpacePoint.position = inputManager.GetCursorWorldPosition();
        transform.up = worldSpacePoint.position - this.transform.position;
        
    }
}
