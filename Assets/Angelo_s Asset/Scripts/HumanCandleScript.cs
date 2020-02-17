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
<<<<<<< HEAD
            GameControllerRef.GetComponent<GameController>().counter++;
            print(GameControllerRef.GetComponent<GameController>().counter);
=======
            GameControllerRef.GetComponent<GameController>().counter ++;
>>>>>>> 883f51f5e7751b46a5270996ad94e819ea8f5c1c
        }   
    }
}
