using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private int _cameraNumber;
    private CameraPositionSetter _cameraPositionSetter = null;

    private void Start()
    {
        if (FindObjectOfType<CameraPositionSetter>() != null)
        {
            _cameraPositionSetter = FindObjectOfType<CameraPositionSetter>();
        }
        else
        {
            Debug.LogWarning("Camera position setter not found in scene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cameraPositionSetter.SetCameraPosition(_cameraNumber);
            Debug.Log("Trigger " + _cameraNumber + " activated");

        }
    }
}
