using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject [] objects;
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {   
        

        foreach (GameObject i in objects)
        {   
            
            objects[num] = other.gameObject;
            
        }

        num++;
    }

}
