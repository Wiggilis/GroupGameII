using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool restartbuttons = false;
    public bool fuctionwascalled = false;
    bool istrue = true;
    bool istrue1 = false;

    public int counter = 0;
    int num  = 0;
    int num1 = 0;
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
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CursorImage.transform.position = Input.mousePosition;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (possesionlimit >= 10) {
            enemy.GetComponent<MeshRenderer>().enabled = true;
            enemy.GetComponent<SphereCollider>().enabled = true;
            enemy.GetComponent<NavMeshPlayerController>().enabled = true;
        }
        if (counter == 3) {

            portal.GetComponent<MeshRenderer>().enabled = true;
            portal.GetComponent<CapsuleCollider>().enabled = true;


        }
        if (playerref.GetComponent<PlayerMovement>().endgame == true) {
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

        if (playerref.GetComponent<PlayerMovement>().losegame == true) {

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

        if (Input.GetKeyDown(KeyCode.P))
        {
            counter++;
        }

        while (istrue) {
            if (playerref.GetComponent<PlayerPossesiom>().roomref.GetComponent<Room>().objects[num].gameObject.tag == "Player") {

                istrue1 = true;

                while (istrue1) {

                    if (playerref.GetComponent<PlayerPossesiom>().roomref.GetComponent<Room>().objects[num1].gameObject.tag == "Enemy") {

                        playerref.GetComponent<PlayerMovement>().losegame = true;
                    
                    }

                    num1++;
                }
            
            }
            num++;
            if (num > 20) {

                num = 0;
            
            }
        }

        
    }

    public void buttonclicked() {
        if (Input.GetKey(KeyCode.Mouse0)) {
            restartbuttons = true;
        }
    }
    
   
 
}
