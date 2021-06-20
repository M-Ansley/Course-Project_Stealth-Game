using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void StartGame()
    {
        Debug.Log("Should start game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
