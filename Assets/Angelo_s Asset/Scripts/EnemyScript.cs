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

            if (trigExit == false)
            {
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
        while (trigExit)
        {
            if (roomref.GetComponent<Room>().objects[num1].gameObject.name == "Enemy")
            {

                roomref.GetComponent<Room>().objects[num1] = null;


                trigExit = false;

                print("num1: " + num1);
                print("TrigExit: " + trigExit);
            }
            num1++;
        }
    }
}
