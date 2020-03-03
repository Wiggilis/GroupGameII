using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossesionTimer : MonoBehaviour
{
    public float timer = 5;
    int num;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            while (num < GetComponent<PlayerPossesiom>().roomref.GetComponent<Room>().objects.Length)
            {
                if (GetComponent<PlayerPossesiom>().roomref.GetComponent<Room>().objects[num].CompareTag("Human"))
                {
                    GetComponent<PlayerPossesiom>().roomref.GetComponent<Room>().objects[num].gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
                }
                num++;
            }
        }

        num = 0;
       
    }

}
