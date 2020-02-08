using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody cubeRogidbody;
    public float forcesPower;
    private bool Wispress = false;
    private bool Aispress = false;
    private bool Sispress = false;
    private bool Dispress = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate() {
        if (Wispress == true)
        {
            cubeRogidbody.AddForce(Vector3.forward * forcesPower);
            Wispress = false;
        }
        if (Sispress == true)
        {
            cubeRogidbody.AddForce(Vector3.back * forcesPower);
            Sispress = false;
        }
        if (Aispress == true)
        {
            cubeRogidbody.AddForce(Vector3.left * forcesPower);
            Aispress = false;
        }
        if (Dispress == true)
        {
            cubeRogidbody.AddForce(Vector3.right * forcesPower);
            Dispress = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
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
