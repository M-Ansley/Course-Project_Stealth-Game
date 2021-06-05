using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GameEvents.current.DarrenCaught();
            Debug.Log("Darren spotted!");
        }
    }
}
