using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerPossesiom : MonoBehaviour
{

    private CameraChange CameraChangeScript;
    public GameObject CameraController;
    private GameObject people;
    private Transform playerposition;
    
    public GameObject roomref;
    public GameObject HumanRef;
    public GameObject player;
    public GameObject cameraObject;
    public GameObject CursorImage;
    public GameObject gameController;
    public GameObject Human; 
    public Text countDownTextRef;

    public  bool isGhost = true;
    public bool isClick = false;
    public bool lightonoff = true;

    int num = 0;

    RaycastHit rhinfo;

    private void Start()
    {
        CameraChangeScript = CameraController.GetComponent<CameraChange>(); 
    }


    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isClick = true;

            if (isClick && isGhost)
            {

                GetRayInfo();



                if (rhinfo.collider.tag == "Human" && rhinfo.collider.GetComponentInChildren<SpriteRenderer>().enabled == true)
                {
                    
                    HumanRef = rhinfo.collider.gameObject;

                    if (rhinfo.collider.GetComponent<HumanMovenet>() != null)
                    {
                        rhinfo.collider.GetComponent<HumanMovenet>().enabled = true;
                    }
                    
                    Possesion();

                }



                if (rhinfo.collider.tag == "LightSource")
                {
                    num = 0;
                    starttimer();

                    if (rhinfo.collider.GetComponent<TurnOffLight>().lightRef.GetComponent<Light>().enabled == true)
                    {
                        rhinfo.collider.GetComponent<TurnOffLight>().lightRef.GetComponent<Light>().enabled = false;
                        /*if (rhinfo.collider.GetComponent<TurnOffLight>().lightRef2.GetComponent<Light>().enabled == true)
                        {
                            rhinfo.collider.GetComponent<TurnOffLight>().lightRef2.GetComponent<Light>().enabled = false;
                        }*/
                    }

                    else if (rhinfo.collider.GetComponent<TurnOffLight>().lightRef.GetComponent<Light>().enabled == false)
                    {
                        rhinfo.collider.GetComponent<TurnOffLight>().lightRef.GetComponent<Light>().enabled = true;
                        /*if (rhinfo.collider.GetComponent<TurnOffLight>().lightRef2.GetComponent<Light>().enabled == false)
                        {
                            rhinfo.collider.GetComponent<TurnOffLight>().lightRef2.GetComponent<Light>().enabled = true;
                        }*/
                    }


                    foreach (GameObject i in roomref.GetComponent<Room>().objets1)
                    {

                        if (roomref.GetComponent<Room>().objets1[num].gameObject.tag == "Human")
                        {
                            
                            roomref.GetComponent<Room>().objets1[num].GetComponentInChildren<SpriteRenderer>().enabled = true;

                        }

                        num++;

                    }

                }
            }
        }
        
        if (GetComponent<PossesionTimer>().timer < 0) 
        {

             stoptimer();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {


            if (!isGhost)
             {
                //HumanRef.GetComponent<NavMeshHumanController>().enabled = true;

                ReGhost();
             }

        }

        if (countDownTextRef.GetComponent<TimeYouCanSpendInsideAHuman>().timer <= 0) {

            ReGhost();
        
        }

        if (Input.GetButton("Ctrl") && !isGhost)
        {
            CursorImage.SetActive(true);
            HumanRef.GetComponent<HumanMovenet>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (!isGhost)
        {
            CursorImage.SetActive(false);
            HumanRef.GetComponent<HumanMovenet>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Room") {

            roomref = other.gameObject;

        }
    }

    public void GetRayInfo()
    {
        Ray toCursor = Camera.main.ScreenPointToRay(CursorImage.transform.position);
        bool didgit = Physics.Raycast(toCursor, out rhinfo, 500.0f);

    }

    void starttimer() {

        GetComponent<PossesionTimer>().timer = 5;
        GetComponent<PossesionTimer>().enabled = true;

    }
    void stoptimer() {

        GetComponent<PossesionTimer>().enabled = false;
            
    }

    void Possesion() {

        isGhost = false;

        CameraController.GetComponent<WinCon1>().enabled = true;
        
        gameController.GetComponent<GameController>().possesionlimit++;

        countDownTextRef.GetComponent<Text>().enabled = true;
        countDownTextRef.GetComponent<TimeYouCanSpendInsideAHuman>().enabled = true;

        player.GetComponentInChildren<MeshRenderer>().enabled = false;
        player.GetComponent<GhostController>().enabled = false;
        player.transform.position = new Vector3(0f,0f,0f);

        cameraObject.GetComponent<CameraScript>().CameraFollowObj = rhinfo.collider.GetComponent<CameraGuideRefernce>().CamGuideRef;
        cameraObject.GetComponent<CameraScript>().LookAtObject = rhinfo.collider.GetComponent<CameraGuideRefernce>().LookAtRef;
        cameraObject.transform.rotation = rhinfo.collider.transform.rotation;

        CameraChangeScript.CamMode = 1;
        CameraChangeScript.RestoreMaterials();

        StartCoroutine(CameraChangeScript.CamChange());

        HumanRef.GetComponent<NavMeshHumanController>().enabled = false;
        HumanRef.GetComponent<NavMeshHumanController>().agent.enabled = false;

    }

    void ReGhost() {

        isGhost = true;
        isClick = false;

        HumanRef.GetComponent<NavMeshHumanController>().enabled = true;
        HumanRef.GetComponent<NavMeshHumanController>().agent.enabled = true;

        player.GetComponentInChildren<MeshRenderer>().enabled = true;
        player.GetComponent<GhostController>().enabled = true; 
        player.transform.position = rhinfo.collider.transform.position;

        CameraController.GetComponent<WinCon1>().enabled = false;

        countDownTextRef.GetComponent<Text>().enabled = false;
        countDownTextRef.GetComponent<TimeYouCanSpendInsideAHuman>().timer = 25;
        countDownTextRef.GetComponent<TimeYouCanSpendInsideAHuman>().enabled = false;
       
        rhinfo.collider.GetComponent<HumanMovenet>().enabled = false;
       
        cameraObject.transform.rotation = player.transform.rotation;
        cameraObject.GetComponent<CameraScript>().CameraFollowObj = player.GetComponent<CameraGuideRefernce>().CamGuideRef;
        cameraObject.GetComponent<CameraScript>().LookAtObject = player.GetComponent<CameraGuideRefernce>().LookAtRef;
        
        CursorImage.SetActive(false);
    }
}
