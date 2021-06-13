using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeycardActivation : MonoBehaviour
{
    [SerializeField] private GameObject _grabKeycardCutscene = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _grabKeycardCutscene.SetActive(true);
        }
    }
}
