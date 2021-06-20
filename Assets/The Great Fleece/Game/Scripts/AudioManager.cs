using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // SINGLETON SETUP
    private static AudioManager _current;

    public static AudioManager Current
    {
        get
        {
            if (_current == null)
            {
                Debug.LogError("AudioManager is null");
                return null;
            }
            else
            {
                return _current;
            }
        }
    }

    [SerializeField] private AudioSource audioSource;


    private void Awake()
    {
        _current = this;
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
