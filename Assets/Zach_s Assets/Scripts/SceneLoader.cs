using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Image progressBar1;
    [SerializeField]
    private Image progressBar2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneOp());
    }

    // Update is called once per frame
    IEnumerator LoadSceneOp()
    {
        AsyncOperation LevelProgress = SceneManager.LoadSceneAsync("Angelo_s Scene");
        
        while (LevelProgress.progress < 1)
        {
            progressBar1.fillAmount = LevelProgress.progress;
            progressBar2.fillAmount = LevelProgress.progress;
            yield return new WaitForEndOfFrame();
        }

    }
}
