﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //private LineRenderer _lineRenderer;

    // handle to nav mesh agent
    private NavMeshAgent _agent;

    [SerializeField] private Animator _animator;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(hitInfo.point); // hitInfo.transform.position will return the transform.position of the object hit, not that of the point of collision
                _agent.SetDestination(hitInfo.point);
                _animator.SetBool("Moving", true);
                // _lineRenderer.SetPosition(0, this.transform.position);
            }
        }


        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    _animator.SetBool("Moving", false);
                }
            }
        }

        //float dist = _agent.remainingDistance;

        //if (dist != Mathf.Infinity && _agent.pathStatus == NavMeshPathStatus.PathComplete && _agent.remainingDistance == 0) // remaining distance appears to be Mathf.Infinity until the agent becomes relatively close to teh destination. Not a value we can rely on.
        //{
        //    _animator.SetBool("Moving", false);
        //}




    }
}