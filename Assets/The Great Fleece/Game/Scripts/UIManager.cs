using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _current;

    public UIManager Current
    {
        get
        {
            if (_current == null)
            {
                Debug.LogError("UIManager is null");
                return null;
            }
            else
            {
                return _current;
            }
        }
    }


    private void Awake()
    {
        _current = this;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // restarts this scene
    }

    public void Quit()
    {
        Application.Quit();
    }


}
