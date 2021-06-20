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


    public enum CutsceneType
    {
        KeyCard = 0,
        Fail = 1,
        Win = 2,
        Intro = 3
    }

    public CutsceneType _cutsceneType;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_cutscenePlayed)
            {
                PlayCutscene();
            }
        }
    }

    public void PlayCutscene()
    {
        CutsceneTypeLogic();
    }

    private void CutsceneTypeLogic()
    {
        switch (_cutsceneType)
        {
            case CutsceneType.KeyCard:
                GameLogic.Current.HasCard = true;
                _cutsceneGameObject.SetActive(true);
                DisableObjects();
                _playableDirector.stopped += EnableObjects;
                _playableDirector.stopped += DisableCutscene;
                _cutscenePlayed = true;
                break;
            case CutsceneType.Fail:
                break;
            case CutsceneType.Win:
                if (GameLogic.Current.HasCard)
                {
                    _cutsceneGameObject.SetActive(true);
                    DisableObjects();
                    GameLogic.Current.gameOver = true;
                    _cutscenePlayed = true;
                }
                break;
            case CutsceneType.Intro:
                _cutsceneGameObject.SetActive(true);
                DisableObjects();
                _playableDirector.stopped += EnableObjects;
                _playableDirector.stopped += DisableCutscene;
                _playableDirector.stopped += GameSetup;
                _cutscenePlayed = true;

                break;
                
            default:
                break;
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

    private void GameSetup(PlayableDirector pd)
    {
        GameLogic.Current.IntroCutsceneFinished();
    }



    public void SkipToPoint(float point)
    {
        if (_cutsceneGameObject != null)
        {
            _playableDirector.time = 58f;
        }
    }
}
