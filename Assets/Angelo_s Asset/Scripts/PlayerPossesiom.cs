using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossesiom : MonoBehaviour
{
    public MeshRenderer playerMR;
    public GameObject player;
    public GameObject camera;
    public GameObject walls;
    private GameObject people;

    private Transform playerposition;
    
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rhinfo;
        RaycastHit rhinfom;
        bool didgit = Physics.Raycast(toMouse, out rhinfo, 500.0f);

        print(rhinfo.collider.gameObject.tag);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (rhinfo.collider.tag == "Human") {
                playerMR.enabled = false;
                player.GetComponent<ThirdPersonCharacterControl>().enabled = false;
                camera.GetComponent<CameraScript>().CameraFollowObj = rhinfo.collider.GetComponent<CameraGuideRefernce>().CamGuideRef;
                camera.transform.rotation = rhinfo.collider.transform.rotation;
                rhinfom = rhinfo;
                if (rhinfo.collider.GetComponent<HumanMovenet>() != null) {
                    rhinfo.collider.GetComponent<HumanMovenet>().enabled = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (rhinfo.collider.tag == "Human") {
                playerMR.enabled = true;
                player.GetComponent<ThirdPersonCharacterControl>().enabled = true;
                rhinfo.collider.GetComponent<HumanMovenet>().enabled = false;
                camera.GetComponent<CameraScript>().CameraFollowObj = player.GetComponent<CameraGuideRefernce>().CamGuideRef;
                camera.transform.rotation = player.transform.rotation;
                player.transform.position = rhinfo.collider.transform.position;
            }
        }

    }
}
