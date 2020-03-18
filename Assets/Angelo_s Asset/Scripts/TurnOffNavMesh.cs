using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffNavMesh : MonoBehaviour
{
    Vector3 startlocation;
    // Start is called before the first frame update
    void Start()
    {
        startlocation = new Vector3(-177f, 111f, -92f);
    }

    // Update is called once per frame
    void Update()
    {
        if (startlocation.x >= transform.position.x) {

            GetComponent<NavMeshHumanController>().enabled = false;
        }
    }
}
