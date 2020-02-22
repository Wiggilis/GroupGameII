﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossesiom : MonoBehaviour
{
    public MeshRenderer playerMR;
    public GameObject player;
    public GameObject camera;
    public GameObject walls;
    public GameObject cursor;
    private GameObject people;
    private Transform playerposition;
    RaycastHit rhinfo;
    public bool isGhost = true;
    private bool isClick = false;
    public float timer = 0;
    public GameObject roomref;    

    
   
    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isClick = true;

            if (isClick && isGhost)
            {
                
                GetRayInfo();

                if (rhinfo.collider.tag == "Human" && roomref.GetComponent<BoxOverLay>().hitColliders[2].GetComponentInChildren<SpriteRenderer>().enabled == true)
                 {
                    playerMR.enabled = false;
                    player.GetComponent<ThirdPersonCharacterControl>().enabled = false;
                    camera.GetComponent<CameraScript>().CameraFollowObj = rhinfo.collider.GetComponent<CameraGuideRefernce>().CamGuideRef;
                    camera.transform.rotation = rhinfo.collider.transform.rotation;
                    isGhost = false;
                    if (rhinfo.collider.GetComponent<HumanMovenet>() != null)
                    {
                        rhinfo.collider.GetComponent<HumanMovenet>().enabled = true;
                    }
                  }
                
                
            }

            if (rhinfo.collider.tag == "LightSource")
            {

                rhinfo.collider.GetComponent<TurnOffLight>().lightRef.SetActive(false);
                roomref.GetComponent<BoxOverLay>().hitColliders[2].GetComponentInChildren<SpriteRenderer>().enabled = true;
                while (timer * Time.deltaTime < 600 * Time.deltaTime) {

                    print(timer);
                    roomref.GetComponent<BoxOverLay>().hitColliders[2].GetComponentInChildren<SpriteRenderer>().enabled = false;
                    timer++;
                }
            }

            
        }



        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
                if (rhinfo.collider.tag == "LightSource") {

                rhinfo.collider.GetComponent<TurnOffLight>().lightRef.SetActive(true);

                }
                
                playerMR.enabled = true;
                player.GetComponent<ThirdPersonCharacterControl>().enabled = true;
                rhinfo.collider.GetComponent<HumanMovenet>().enabled = false;
                player.transform.position = rhinfo.collider.transform.position;
                camera.transform.rotation = player.transform.rotation;
                camera.GetComponent<CameraScript>().CameraFollowObj = player.GetComponent<CameraGuideRefernce>().CamGuideRef;
                isGhost = true;

        }

    }

    void GetRayInfo()
    {
        Ray toCursor = Camera.main.ScreenPointToRay(cursor.transform.position);
        bool didgit = Physics.Raycast(toCursor, out rhinfo, 500.0f);

        print(rhinfo.collider.gameObject.tag);
    }

}
