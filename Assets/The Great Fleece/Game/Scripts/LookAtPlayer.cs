using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private GameObject _player;
    public Transform startCamera;

    private void Start()
    {
        transform.position = startCamera.position;
        transform.rotation = startCamera.rotation;
        if (FindObjectOfType<Player>() != null)
        {
            _player = FindObjectOfType<Player>().gameObject;
        }
    }



    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.LookAt(_player.transform);
    }
}
