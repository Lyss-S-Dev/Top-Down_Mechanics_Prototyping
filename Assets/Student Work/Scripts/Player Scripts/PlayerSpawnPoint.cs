using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    
    private void Awake()
    {
        Instantiate(playerPrefab, this.transform.position, quaternion.identity);
    }

    
}
