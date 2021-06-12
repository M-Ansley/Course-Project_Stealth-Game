using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
   [SerializeField] private Animator _animator = null;

    private void Start()
    {
        GameEvents.current.darrenCaught += StopCamera;
        GameEvents.current.darrenCaught += ChangeRendererColour;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameOverSequence(0.5f));
        }
    }

    private IEnumerator GameOverSequence(float delay)
    {
        StopCamera();
        ChangeRendererColour();
        yield return new WaitForSecondsRealtime(delay);
        GameEvents.current.DarrenCaught();
    }

    private void StopCamera()
    {
        _animator.enabled = false;
    }

    private void ChangeRendererColour()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        Color color = new Color(0.6f, .1f, .1f, .3f);
        renderer.material.SetColor("_TintColor", color);
    }
}
