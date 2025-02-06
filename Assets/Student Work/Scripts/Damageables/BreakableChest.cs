using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BreakableChest : BreakableObject
{
    [SerializeField] private int numberOfDrops;
    [SerializeField] private GameObject droppedItem;

    protected override void ObjectDestruction()
    {
        SpawnPickups();
        AudioPlayer.instance.PlayClipAtPosition("Chest Broken");
        ScoringManager.instance.TickUpActionCounter();
        Destroy(this.gameObject);
    }

    private void SpawnPickups()
    {
        for (int iter = 0; iter < numberOfDrops ; iter++)
        {
            GameObject spawnedItem = Instantiate(droppedItem, transform.position, quaternion.identity);
            spawnedItem.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 1f, ForceMode2D.Impulse);
        }
    }
}
