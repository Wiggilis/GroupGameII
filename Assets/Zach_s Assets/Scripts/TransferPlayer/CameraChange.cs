using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject Player;
    public GameObject CursorImage;
    public GameObject ThirdPersonCamera;
    public GameObject FirstPersonCamera;
    private PlayerPossesiom isGhost;
    private bool isPaused = false;
    public int CamMode;

    [SerializeField] private Material highlightMaterial;
    private int i = 0;
    public Material[] MaterialsArray;
    public GameObject[] interactables;
    public GameObject[] Humans;


    private void Start()
    {
        interactables = GameObject.FindGameObjectsWithTag("GameObject");
        Humans = GameObject.FindGameObjectsWithTag("Human");
        MaterialsArray = new Material[interactables.Length + Humans.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (Player.GetComponent<PlayerPossesiom>().isGhost)
            {
                if (CamMode == 1)
                {
                    CamMode = 0;
                    //Cursor.visible = false;
                    CreateMaterialArray();
                }
                else
                {
                    CamMode += 1;
                    //Cursor.visible = true;
                    RestoreMaterials();
                }
                StartCoroutine(CamChange());
            }

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

    public void CreateMaterialArray()
    {

        foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("GameObject"))
        {
            //Do something to ObjectFound, like this:
            MaterialsArray[i] = ObjectFound.GetComponent<Renderer>().material;
            i++;
            ObjectFound.GetComponent<Renderer>().material = highlightMaterial;
        }

        foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Human"))
        {
            //Do something to ObjectFound, like this:
            MaterialsArray[i] = ObjectFound.GetComponent<Renderer>().material;
            i++;
            ObjectFound.GetComponent<Renderer>().material = highlightMaterial;
        }

        i = 0;
    }

    public void RestoreMaterials()
    {
        foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("GameObject"))
        {
            //Do something to ObjectFound, like this:
            ObjectFound.GetComponent<Renderer>().material = MaterialsArray[i];
            i++;
        }

        foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Human"))
        {
            //Do something to ObjectFound, like this:
            ObjectFound.GetComponent<Renderer>().material = MaterialsArray[i];
            i++;
        }

        i = 0;
    }
}
