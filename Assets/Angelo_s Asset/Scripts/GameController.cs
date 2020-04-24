using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool restartbuttons = false;
    public bool fuctionwascalled = false;
    public bool tencandle = false;
    bool pausemenu = false;

    public int counter = 0;

    public GameObject CursorImage;
    public GameObject humanCandleRef;
    public Text candlesFound;
    public GameObject portal;
    public GameObject playerref;
    public GameObject youWinRef;
    public GameObject restartButtonRef;
    public GameObject backgroundref;
    public GameObject countdown;
    public GameObject Instru;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        CursorImage.transform.position = Input.mousePosition;

        /*if (Cursor.visible == true)
        {
            //Cursor.visible = false;
        }*/

        if (Input.GetKeyDown(KeyCode.Mouse0) && Instru.activeSelf == true) {

            Instru.SetActive(false);
        }

        if (Instru.activeSelf == false) {

            playerref.SetActive(true);
            pausemenu = true;
        }
        if (pausemenu == true) {
            if (Input.GetKey(KeyCode.F)) {

                Instru.SetActive(true);

            }
            if (!Input.GetKey(KeyCode.F))
            {

                Instru.SetActive(false);

            }
        }

        if (tencandle == true) {

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

            if (restartbuttons == true) 
            {
                SceneManager.LoadScene("Angelo_s Scene");
            }
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
