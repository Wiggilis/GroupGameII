using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalktoWall : MonoBehaviour
{
    public Rigidbody playerRb;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Wall")
        {
            Collision.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }



}
