using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _voiceOverClip;

    private GameObject _mainCameraObject = null;
    private bool _played = false;


    private void Start()
    {
        try
        {
            _mainCameraObject = Camera.main.gameObject;
        }
        catch { }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_played && _voiceOverClip != null)
            {
                if (_mainCameraObject != null)
                {
                    if (_mainCameraObject.TryGetComponent(out AudioSource audioSource))
                    {
                        audioSource.PlayOneShot(_voiceOverClip);
                    }
                }
                else
                {
                    AudioSource.PlayClipAtPoint(_voiceOverClip, transform.position); // play it at the position of this object if not
                }
                _played = true;
            }
        }
    }
}
