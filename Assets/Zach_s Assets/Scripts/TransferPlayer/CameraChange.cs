using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject Player;
    public GameObject CursorImage;
    public GameObject ThirdPersonCamera;
    public GameObject FirstPersonCamera;
    private bool isPaused = false;
    public int CamMode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine (CamChange ());
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused == false)
            {
                isPaused = true;
                Cursor.visible = true;
                ThirdPersonCamera.GetComponent<ThirdPersonCamera>().enabled = false;
                FirstPersonCamera.GetComponent<FirstPersonCamera>().enabled = false;
            }
            else
            {
                isPaused = false;
                Cursor.visible = false;
                ThirdPersonCamera.GetComponent<ThirdPersonCamera>().enabled = true;
                FirstPersonCamera.GetComponent<FirstPersonCamera>().enabled = true;
            }
        }
    }

    public IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if(CamMode == 0)
        {
            ThirdPersonCamera.SetActive(true);
            FirstPersonCamera.SetActive(false);
            Player.GetComponent<GhostController>().enabled = false;
            Player.GetComponent<PlayerPossesiom>().enabled = true;
            CursorImage.SetActive(true);
        }
        if(CamMode == 1)
        {
            FirstPersonCamera.SetActive(true);
            ThirdPersonCamera.SetActive(false);
            Player.GetComponent<GhostController>().enabled = true;
            //Player.GetComponent<PlayerPossesiom>().enabled = false;
            CursorImage.SetActive(false);
        }
    }
}
