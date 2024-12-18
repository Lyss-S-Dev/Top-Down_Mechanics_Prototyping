using System;
using System.Collections;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float objectLifetime = 5f;

    private void Awake()
    {
        StartCoroutine(nameof(DestroyAfterSeconds));
    }

    private IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(objectLifetime);
        Destroy(this.gameObject);
    }
}
