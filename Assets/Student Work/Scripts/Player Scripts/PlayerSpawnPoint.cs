using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instantiate(playerPrefab, this.transform.position, quaternion.identity);
    }

    
}
