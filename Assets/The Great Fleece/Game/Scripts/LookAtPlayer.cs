using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private GameObject _player;
    public Transform startCamera;

    private void Awake()
    {
        if (FindObjectOfType<Player>() != null)
        {
            _player = FindObjectOfType<Player>().gameObject;
        }
    }

    private void Start()
    {
        transform.position = startCamera.position;
        transform.rotation = startCamera.rotation;       
    }

    public void DelayedStart()
    {
        if (FindObjectOfType<Player>() != null)
        {
            _player = FindObjectOfType<Player>().gameObject;
        }
        transform.position = startCamera.position;
        transform.rotation = startCamera.rotation;

            
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        transform.LookAt(_player.transform);
    }
}
