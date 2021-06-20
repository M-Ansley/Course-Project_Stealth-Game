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
    [SerializeField] private GameObject _gameOverCutscene = null;

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
    }

    private void DarrenCaught()
    {
        if (!gameOver)
        {
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
