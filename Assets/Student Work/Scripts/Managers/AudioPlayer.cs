using System;
using UnityEngine;

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

    public static AudioPlayer Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
