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
        num = 0;

        if (timer < 0)
        {
            while (num < GetComponent<PlayerPossesiom>().roomref.GetComponent<Room>().objets1.Length)
            {
                if (GetComponent<PlayerPossesiom>().roomref.GetComponent<Room>().objets1[num].gameObject.tag == "Human")
                {
                    GetComponent<PlayerPossesiom>().roomref.GetComponent<Room>().objets1[num].gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
                }
                num++;
            }
        }

    }

}
