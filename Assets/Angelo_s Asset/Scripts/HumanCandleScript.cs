using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCandleScript : MonoBehaviour
{
    public GameObject GameControllerRef;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "GameObject") {

            Destroy(collision.gameObject);
            GameControllerRef.GetComponent<GameController>().collisionistrue = true;

            print(GameControllerRef.GetComponent<GameController>().counter);
        }   
    }
}
