using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> objectsList = new List<GameObject>();
    public GameObject[] objets1;
    public int num = 0;
    public int num1 = 0;
    public GameObject Player;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    void OnTriggerEnter(Collider other)
    {   
        foreach (GameObject obj in objets1) 
        {

            objets1[num] = other.gameObject;
            
        }num++;

        foreach (GameObject i in objectsList)
        {   
            
            objectsList.Add(other.gameObject);
            
        }
        
    }

     void OnTriggerExit(Collider other)
    {

        foreach (GameObject i in objectsList) {


            if (objectsList.Contains(Player))
            {

                objectsList.Remove(Player);

            }
            

        }

        foreach (GameObject iy in objectsList)
        {

            if (objectsList.Contains(Enemy))
            {

               objectsList.Remove(Enemy);

            }

        }
    }

}
