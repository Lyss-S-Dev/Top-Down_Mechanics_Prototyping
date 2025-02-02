using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class SoundEffect
{
    public GameObject soundClip;
    public string name;
    public float volume;
}


public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private SoundEffect[] audioSources;

    public static AudioPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayClipAtPosition(string clipName, Vector3 position, bool enablePitchVariance)
    {
        foreach (SoundEffect clipPrefab in audioSources)
        {
            if (clipPrefab.name == clipName)
            {
                SpawnClipPrefab(clipPrefab.soundClip, position, clipPrefab.volume,enablePitchVariance);
            }
        }
    }

    private void SpawnClipPrefab(GameObject clipToSpawn, Vector3 position, float volume, bool enablePitchVariance)
    {
       GameObject spawnedClip = Instantiate(clipToSpawn, position, quaternion.identity);
       spawnedClip.GetComponent<AudioSource>().volume = volume;
       if (enablePitchVariance)
       {
           spawnedClip.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1f);
       }
       
    }
    
}
