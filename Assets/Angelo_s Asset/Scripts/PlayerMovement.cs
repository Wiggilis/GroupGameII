using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    public bool endgame = false;
    public bool losegame = false;
    public int ghostNumber;

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.name);
        if(collision.collider.tag == "Portal")
        {
            endgame = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ghostNumber = other.gameObject.GetComponent<RoomNumber>().roomNumberRef;
    }
}
