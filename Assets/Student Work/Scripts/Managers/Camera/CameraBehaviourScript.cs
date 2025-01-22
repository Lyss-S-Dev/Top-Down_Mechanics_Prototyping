using UnityEngine;

public class CameraBehaviourScript : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float zOffset = -10;

    private bool followTarget = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = FindFirstObjectByType<PlayerMover>().GetFollowTarget();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (followTarget)
        {
            transform.position = new Vector3(target.position.x, target.position.y, zOffset);
        }
        
    }
}
