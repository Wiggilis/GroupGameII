using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshHumanController : MonoBehaviour
{

    public NavMeshAgent agent;
    public List<GameObject> roomtogo;
    Vector3 newLocataion;
    int currentindex = 0;
    bool check = true;
    float count = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        newLocataion = roomtogo[currentindex].transform.position;
        agent.SetDestination(newLocataion);

        if (roomtogo[currentindex] == check)
        {

            currentindex = Random.Range(0, 1);
            print(currentindex);

            check = false;

        }

        if (count <= 3)
        {

            count += Time.deltaTime;
            //print(count);

        }
        if (count > 3)
        {

            check = true;
            count = 0;

        }


    }
}
