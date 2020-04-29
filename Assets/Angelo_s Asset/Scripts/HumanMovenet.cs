using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovenet : MonoBehaviour
{
    public Rigidbody cubeRigidbody;
    
    public float forcesPower;
    public float Speed = 10.0f;
    public float RotationSpeed = 100.0f;
    public float movementSpeed = 10;
    public float turningSpeed = 60;


    void Update()
    {      
        HumanMovement();
        if (Input.GetKey(KeyCode.W)) {
            GetComponent<Walkanimation>().Ghost = true;
        }
    }

    void HumanMovement()
    {

        float rotHorizontal = Input.GetAxis("Mouse X") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, rotHorizontal, 0);

        float moveVertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, moveVertical);

        float moveHorizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(moveHorizontal, 0, 0);

        float mouseY = Input.GetAxis("RightStickVertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, -mouseY, 0);
    }


}
