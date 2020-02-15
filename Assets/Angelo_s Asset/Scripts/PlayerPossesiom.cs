using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossesiom : MonoBehaviour
{
    public MeshRenderer playerMR;
    public GameObject playerMovement;
    public GameObject walls;
    private GameObject people;
    
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
                playerMovement.GetComponent<PlayerMovement>().enabled = false;
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
                playerMovement.GetComponent<PlayerMovement>().enabled = true;
                rhinfo.collider.GetComponent<HumanMovenet>().enabled = false;
                
            }
        }

    }
}
