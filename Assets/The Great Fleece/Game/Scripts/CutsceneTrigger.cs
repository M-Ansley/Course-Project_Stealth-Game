using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{

    [SerializeField] private GameObject _cutsceneGameObject = null;
    [SerializeField] private PlayableDirector _playableDirector = null;

    [SerializeField] private GameObject[] _objects = null;

    private bool _cutscenePlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_cutscenePlayed)
            {
                _cutsceneGameObject.SetActive(true);
                DisableObjects();
                _playableDirector.stopped += EnableObjects;
                _playableDirector.stopped += DisableCutscene;
                _cutscenePlayed = true;
            }
        }
    }


    private void DisableObjects()
    {
        Debug.Log("Started");
        foreach (GameObject obj in _objects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }


    private void EnableObjects(PlayableDirector pd)
    {
        Debug.Log("Finished");
        foreach (GameObject obj in _objects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    private void DisableCutscene(PlayableDirector pd)
    {
        _cutsceneGameObject.SetActive(false);
    }
}
