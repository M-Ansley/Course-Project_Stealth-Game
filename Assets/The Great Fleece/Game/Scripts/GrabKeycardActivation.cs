using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeycardActivation : MonoBehaviour
{
    [SerializeField] private GameObject _grabKeycardCutscene = null;

    private bool _cutscenePlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_cutscenePlayed)
            {
                _grabKeycardCutscene.SetActive(true);
                _cutscenePlayed = true;
            }
        }
    }
}
