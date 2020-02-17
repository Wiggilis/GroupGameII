using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject humanCandleRef;
    public bool fuctionwascalled = false;
    public int counter = 0;
    public Text candlesFound;
    public GameObject portal;
    public GameObject playerref;
    public GameObject youWinRef;
    public GameObject restartButtonRef;
    public GameObject 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter == 3) {

            portal.GetComponent<MeshRenderer>().enabled = true;
            portal.GetComponent<CapsuleCollider>().enabled = true;

        }
        if (playerref.GetComponent<PlayerMovement>().endgame == true) {
            
            SceneManager.LoadScene("Angelo_s Scene");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter++;
        }
        

    }

        
    
 
}
