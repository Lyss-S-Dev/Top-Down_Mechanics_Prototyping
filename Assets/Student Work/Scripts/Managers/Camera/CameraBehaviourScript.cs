using UnityEngine;

public class CameraBehaviourScript : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float zOffset = -10;

    private bool followTarget = true;
    
    void Start()
    {
        target = FindFirstObjectByType<PlayerMover>().GetFollowTarget();
    }
    
    void LateUpdate()
    {
        if (followTarget && target)
        {
            transform.position = new Vector3(target.position.x, target.position.y, zOffset);
        }
        
    }
}
