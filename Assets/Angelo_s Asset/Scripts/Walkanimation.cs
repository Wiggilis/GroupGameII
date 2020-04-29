using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkanimation : MonoBehaviour
{
    public bool Ghost = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Ghost == true)
        {

            GetComponent<Animator>().Play("MotherWalkAnim");
        }
        else
        {

            GetComponent<Animator>().Play("New State");

        }
    }
}
