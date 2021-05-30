using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionSetter : MonoBehaviour
{
    [SerializeField] private GameObject[] _cameraPositionObjects;
    private GameObject _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main.gameObject;
    }

    public void SetCameraPosition(int cameraID)
    {
        try
        {
            _mainCamera.transform.position = _cameraPositionObjects[cameraID - 1].transform.position;
            _mainCamera.transform.rotation = _cameraPositionObjects[cameraID - 1].transform.rotation;
        }
        catch
        {

        }

    }

}
