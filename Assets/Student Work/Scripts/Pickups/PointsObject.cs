using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PointsObject : MonoBehaviour, IPickup
{
    [SerializeField] private int pointsValue;
    private bool canPickup;

    private float pickupCooldown = 0.2f;
    private float pickupLifeTime;

    private Rigidbody2D objectBody;

    private void Start()
    {
        pickupLifeTime = 0f;
        transform.eulerAngles = new Vector3(0, 0, Random.Range(1, 359));
    }

    private void Update()
    {
        if (canPickup == false)
        {
            pickupLifeTime += Time.deltaTime;
            if (pickupLifeTime >= pickupCooldown) 
            {
                canPickup = true;
            }
        }
        
    }
    public void HandlePickup()
    {
        ScoringManager.instance.UpdatePlayerScore(pointsValue);
        AudioPlayer.instance.PlayClipAtPosition("Coin");
        ScoringManager.instance.TickUpActionCounter();
        Destroy(this.gameObject);
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerMover>())
        {
            if (canPickup)
            {
                HandlePickup();
            }
                    
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerMover>())
        {
            if (canPickup)
            {
                HandlePickup();
            }
                    
        }
    }
}
