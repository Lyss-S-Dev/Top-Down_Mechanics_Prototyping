using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class SoundEffect
{
    public AudioSource soundClip;
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

    public void PlayClipAtPosition(string clipName)
    {
        foreach (SoundEffect audioClip in audioSources)
        {
            if (clipName == audioClip.name)
            {
                audioClip.soundClip.PlayOneShot(audioClip.soundClip.clip, audioClip.volume);
            }
        }
    }

    
    
}
