using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerPossesiom : MonoBehaviour
{
    public GameObject roomref;
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
    int num = 0;
    int num1 = 0;
    public Text countDownTextRef;
    bool trigExit = true;
 

    
   
    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isClick = true;

            if (isClick && isGhost)
            {
                
                GetRayInfo();
                
                

                if (rhinfo.collider.tag == "Human" && rhinfo.collider.GetComponentInChildren<SpriteRenderer>().enabled == true)
                 {
                    Possesion();

                    if (rhinfo.collider.GetComponent<HumanMovenet>() != null)
                    {
                        rhinfo.collider.GetComponent<HumanMovenet>().enabled = true;
                    }

            }

                if (rhinfo.collider.tag == "LightSource")
                {
                    num = 0;
                    starttimer();

                    rhinfo.collider.GetComponent<TurnOffLight>().lightRef.SetActive(false);

                    while (num < roomref.GetComponent<Room>().objects.Length)
                    {
                        foreach (GameObject i in roomref.GetComponent<Room>().objects)
                        {
                            if (roomref.GetComponent<Room>().objects[num].CompareTag("Human"))
                            {
                                roomref.GetComponent<Room>().objects[num].gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
                            }

                        }
                        num++;
                    }
                }

                if (rhinfo.collider.GetComponentInChildren<SpriteRenderer>().enabled == false) {

                        stoptimer();
                    }
            }

        }
        
        

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
                

                if (rhinfo.collider.tag == "LightSource") {

                rhinfo.collider.GetComponent<TurnOffLight>().lightRef.SetActive(true);

                }

                ReGhost();

        }

        if (countDownTextRef.GetComponent<TimeYouCanSpendInsideAHuman>().timer <= 0) {

            ReGhost();
        
        }

        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Room") {

            roomref = other.gameObject;

            if (trigExit == false) {
                roomref.GetComponent<Room>().objects[num1 - 1] = other.gameObject;
            }


            num1 = 0;
            trigExit = true;
            print("num1: " + num1);
            print("TrigExit: " + trigExit);

        }
    }

     void OnTriggerExit(Collider other)
    {
        while (trigExit) {
            if (roomref.GetComponent<Room>().objects[num1].gameObject.name == "Player") {

                roomref.GetComponent<Room>().objects[num1] = null;


                trigExit = false;

                print("num1: " + num1);
                print("TrigExit: " + trigExit);
            }
            num1++;
        }
    }
    void GetRayInfo()
    {
        Ray toCursor = Camera.main.ScreenPointToRay(cursor.transform.position);
        bool didgit = Physics.Raycast(toCursor, out rhinfo, 500.0f);

        print(rhinfo.collider.gameObject.tag);
    }

    void starttimer() {

        GetComponent<PossesionTimer>().timer = 5;
        GetComponent<PossesionTimer>().enabled = true;

    }
    void stoptimer() {

        GetComponent<PossesionTimer>().enabled = false;
            
    }

    void Possesion() {

        countDownTextRef.GetComponent<Text>().enabled = true;
        countDownTextRef.GetComponent<TimeYouCanSpendInsideAHuman>().enabled = true;
        playerMR.enabled = false;
        player.GetComponent<ThirdPersonCharacterControl>().enabled = false;
        camera.GetComponent<CameraScript>().CameraFollowObj = rhinfo.collider.GetComponent<CameraGuideRefernce>().CamGuideRef;
        camera.transform.rotation = rhinfo.collider.transform.rotation;
        isGhost = false;
    }

    void ReGhost() {

        countDownTextRef.GetComponent<Text>().enabled = false;
        countDownTextRef.GetComponent<TimeYouCanSpendInsideAHuman>().timer = 15;
        countDownTextRef.GetComponent<TimeYouCanSpendInsideAHuman>().enabled = false;
        playerMR.enabled = true;
        player.GetComponent<ThirdPersonCharacterControl>().enabled = true;
        rhinfo.collider.GetComponent<HumanMovenet>().enabled = false;
        player.transform.position = rhinfo.collider.transform.position;
        camera.transform.rotation = player.transform.rotation;
        camera.GetComponent<CameraScript>().CameraFollowObj = player.GetComponent<CameraGuideRefernce>().CamGuideRef;
        isGhost = true;

    }
}
