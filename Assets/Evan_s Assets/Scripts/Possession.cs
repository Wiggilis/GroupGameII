﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{
    public Rigidbody sphereRigidbody;
    public float forcesPower;
    private bool Wispress = false;
    private bool Aispress = false;
    private bool Sispress = false;
    private bool Dispress = false;
    public bool humanpossision = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Wispress == true)
        {
            sphereRigidbody.AddForce(Vector3.forward * forcesPower);
            Wispress = false;
        }
        if (Sispress == true)
        {
            sphereRigidbody.AddForce(Vector3.back * forcesPower);
            Sispress = false;
        }
        if (Aispress == true)
        {
            sphereRigidbody.AddForce(Vector3.left * forcesPower);
            Aispress = false;
        }
        if (Dispress == true)
        {
            sphereRigidbody.AddForce(Vector3.right * forcesPower);
            Dispress = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (humanpossision == true) {
            if (Input.GetKey(KeyCode.W))
            {
                Wispress = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Sispress = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Aispress = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Dispress = true;
            }
        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            GetComponent<Collider>().enabled = false;
        }
    }*/
}
