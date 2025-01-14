using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float zOffset = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = FindFirstObjectByType<PlayerMover>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, zOffset);
    }
}
