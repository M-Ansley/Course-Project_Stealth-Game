using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    // SINGLETON SETUP
    private static GameLogic _current;

    public static GameLogic Current
    {
        get
        {
            if (_current == null)
            {
                Debug.LogError("GameLogic is null");
                return null;
            }
            else
            {
                return _current;
            }
        }
    } // public instance property which returns a private property (which cannot be changed from the outside)


    [SerializeField] private GameObject _player = null;
    [SerializeField] private CutsceneTrigger _introCutsceneTrigger;
    [SerializeField] private GameObject _gameOverCutscene = null;

    [SerializeField] private LookAtPlayer _lookAtPlayer = null;

    [SerializeField] private GameObject _mainAudioParent = null;

    public bool HasCard { get; set; } // public property. Typically best to use PascalCasing.
    
    

    [HideInInspector]
    public bool gameOver = false;

    private void Awake()
    {
        _current = this;
    }

    private void Start()
    {
        GameEvents.current.darrenCaught += DarrenCaught;
        _introCutsceneTrigger.PlayCutscene();
    }

    public void IntroCutsceneFinished()
    {
        _lookAtPlayer.DelayedStart();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _introCutsceneTrigger.SkipToPoint(60f);
        }
    }

    private void DarrenCaught()
    {
        if (!gameOver)
        {
            //AudioManager.Current.musicSource.Stop();
            _mainAudioParent.SetActive(false);
            _gameOverCutscene.SetActive(true);
            _player.SetActive(false);
            gameOver = true;
        }
    }

    public void ResetGame()
    {
        _gameOverCutscene.SetActive(false);
        _player.SetActive(true);
        gameOver = false;
    }

}
