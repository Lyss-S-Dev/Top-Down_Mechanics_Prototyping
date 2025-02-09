using System;
using System.Collections;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    //this script is used to destroy certain objects after a set time
    //used for instantiated particles and projectiles
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
