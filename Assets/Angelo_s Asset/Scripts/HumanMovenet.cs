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

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {      
        HumanMovement();
    }

    void HumanMovement()
    {
        /*float translationx = Input.GetAxis("Horizontal") * Speed;
        float translationz = Input.GetAxis("Vertical") * Speed;
        float inputy = Input.GetAxis("RightStickVertical") * Speed;
        float rotation = Input.GetAxis("Mouse X") * RotationSpeed;
        translationx *= Time.deltaTime;
        translationz *= Time.deltaTime;
        inputy *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(translationx, inputy, translationz);
        transform.Rotate(0, rotation, 0);*/

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
