﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool restartbuttons = false;
    public bool fuctionwascalled = false;
    bool losegame = false;

    public int counter = 0;
    public int possesionlimit = 0;

    public GameObject CursorImage;
    public GameObject humanCandleRef;
    public Text candlesFound;
    public GameObject portal;
    public GameObject playerref;
    public GameObject youWinRef;
    public GameObject restartButtonRef;
    public GameObject backgroundref;
    public GameObject countdown;
    public GameObject loseBG;
    public GameObject loseText;
    public GameObject enemy;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CursorImage.transform.position = Input.mousePosition;

        if (Cursor.visible == true)
        {
            Cursor.visible = false;
        }

        if (possesionlimit >= 10) {
            enemy.GetComponent<MeshRenderer>().enabled = true;
            enemy.GetComponent<SphereCollider>().enabled = true;
            enemy.GetComponent<NavMeshPlayerController>().enabled = true;
            
        }
        if (counter >= 10) {

            portal.GetComponent<MeshRenderer>().enabled = true;
            portal.GetComponent<CapsuleCollider>().enabled = true;

        }
        if (playerref.GetComponent<PlayerMovement>().endgame == true) 
        {
            backgroundref.GetComponent<Image>().enabled = true;
            restartButtonRef.GetComponent<Image>().enabled = true;
            restartButtonRef.GetComponent<Button>().enabled = true;
            restartButtonRef.GetComponentInChildren<Text>().enabled = true;
            youWinRef.GetComponent<Text>().enabled = true;
            countdown.GetComponent<Text>().enabled = false;

            buttonclicked();

            if (restartbuttons == true) {

                SceneManager.LoadScene("Angelo_s Scene");
            }
        }

        if (losegame == true) {

            loseBG.GetComponent<Image>().enabled = true;
            loseText.GetComponent<Text>().enabled = true;
            restartButtonRef.GetComponent<Image>().enabled = true;
            restartButtonRef.GetComponent<Button>().enabled = true;
            restartButtonRef.GetComponentInChildren<Text>().enabled = true;
            
            buttonclicked();

            if (restartbuttons == true)
            {

                SceneManager.LoadScene("Angelo_s Scene");
            }
        }
            

            if (playerref.GetComponent<PlayerPossesiom>().roomref.GetComponent<Room>().objectsList.Contains(playerref) && 
                playerref.GetComponent<PlayerPossesiom>().roomref.GetComponent<Room>().objectsList.Contains(enemy)) 
            {

                        losegame = true;

            }
    }

    public void buttonclicked() {
        if (Input.GetKey(KeyCode.Mouse0)) {
            restartbuttons = true;
        }
    }
    
   public void IncreaseCounter()
    {

        counter+=1;

    }
 
}
