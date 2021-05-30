using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //private LineRenderer _lineRenderer;

    // handle to nav mesh agent
    private NavMeshAgent _agent;


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
                // _lineRenderer.SetPosition(0, this.transform.position);
            }
        }

    }
}
