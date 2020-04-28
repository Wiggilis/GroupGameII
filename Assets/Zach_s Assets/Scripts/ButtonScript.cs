using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject gamecontrol;

    public void playButton(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void Gamecontrol() {

        gamecontrol.SetActive(true);

    }

    public void BacktoMenu() {

        gamecontrol.SetActive(false);
    
    }
}
