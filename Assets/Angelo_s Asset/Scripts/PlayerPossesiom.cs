using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossesiom : MonoBehaviour
{
    public MeshRenderer playerMR;
    public GameObject playerMovement;
    public GameObject humanpossesion1;
    public GameObject walls;
    
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rhinfo;
        bool didgit = Physics.Raycast(toMouse, out rhinfo, 500.0f);


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (rhinfo.collider.name == "Human") {
                playerMR.enabled = false;
                playerMovement.GetComponent<PlayerMovement>().enabled = false;
                humanpossesion1.GetComponent<Possession>().humanpossision = true;
                playerMovement.GetComponent<WalktoWall>();
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (rhinfo.collider.name != "Human") {
                playerMR.enabled = true;
                playerMovement.GetComponent<PlayerMovement>().enabled = true;
                humanpossesion1.GetComponent<Possession>().humanpossision = false;
            }
        }

    }
}
