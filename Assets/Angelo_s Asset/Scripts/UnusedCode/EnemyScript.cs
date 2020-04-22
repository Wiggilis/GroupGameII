using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject roomref;
    public bool trigExit = true;
    int num1 = 0;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Room")
        {

            roomref = other.gameObject;


        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
