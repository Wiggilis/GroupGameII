using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovenet : MonoBehaviour
{
    public Rigidbody cubeRigidbody;
    public float forcesPower;
    private bool Wispress = false;
    private bool Aispress = false;
    private bool Sispress = false;
    private bool Dispress = false;
    public float Speed = 10.0f;
    public float RotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        /*if (Wispress == true)
        {
            cubeRigidbody.AddForce(Vector3.forward * forcesPower);
            Wispress = false;
        }
        if (Sispress == true)
        {
            cubeRigidbody.AddForce(Vector3.back * forcesPower);
            Sispress = false;
        }
        if (Aispress == true)
        {
            cubeRigidbody.AddForce(Vector3.left * forcesPower);
            Aispress = false;
        }
        if (Dispress == true)
        {
            cubeRigidbody.AddForce(Vector3.right * forcesPower);
            Dispress = false;
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.W))
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
        }*/

        HumanMovement();
    }

    void HumanMovement()
    {
        float translationx = Input.GetAxis("Horizontal") * Speed;
        float translationz = Input.GetAxis("Vertical") * Speed;
        float inputy = Input.GetAxis("RightStickVertical") * Speed;
        float rotation = Input.GetAxis("RightStickHorizontal") * RotationSpeed;
        translationx *= Time.deltaTime;
        translationz *= Time.deltaTime;
        inputy *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(translationx, inputy, translationz);
        transform.Rotate(0, rotation, 0);
    }
}
