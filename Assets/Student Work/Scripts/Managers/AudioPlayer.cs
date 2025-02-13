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

    
    /// <summary>
    /// Plays a 2D audio source of the given name
    /// </summary>
    /// <param name="clipName">Name of the audio clip you want to play</param>
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
