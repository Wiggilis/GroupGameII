using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    public bool endgame = false;
    public bool losegame = false;
    public int ghostNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate() {

    }
    // Update is called once per frame
    void Update()
    {

    }
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
