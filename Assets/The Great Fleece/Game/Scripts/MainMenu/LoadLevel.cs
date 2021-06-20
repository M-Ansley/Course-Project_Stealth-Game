using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Image fillImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            fillImage.fillAmount = progress;
            Debug.Log(progress);
            yield return null;
        }

        fillImage.fillAmount = 1;
    }

}
