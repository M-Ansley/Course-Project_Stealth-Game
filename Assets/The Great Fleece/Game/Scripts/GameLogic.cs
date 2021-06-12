﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField] private GameObject _gameOverCutscene = null;

    [HideInInspector]
    public bool gameOver = false;

    private void Start()
    {
        GameEvents.current.darrenCaught += DarrenCaught;
    }

    private void DarrenCaught()
    {
        if (!gameOver)
        {
            _gameOverCutscene.SetActive(true);
            gameOver = true;
        }
    }

    public void ResetGame()
    {
        _gameOverCutscene.SetActive(false);
        gameOver = false;
    }

}