﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffNavMesh : MonoBehaviour
{
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Human")
        {

            collision.gameObject.transform.localPosition = new Vector3(-176.5295f, 110.5212f, -92.44244f);
            collision.gameObject.GetComponent<NavMeshHumanController>().agent.enabled = false;
            collision.gameObject.GetComponent<NavMeshHumanController>().enabled = false;
            box.SetActive(false);
        }
    }
}