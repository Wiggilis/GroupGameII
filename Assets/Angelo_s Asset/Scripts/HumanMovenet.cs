using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovenet : MonoBehaviour
{
    public Rigidbody cubeRigidbody;
    public float forcesPower;
    public float Speed = 10.0f;
    public float RotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {      
        HumanMovement();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void HumanMovement()
    {
        float translationx = Input.GetAxis("Horizontal") * Speed;
        float translationz = Input.GetAxis("Vertical") * Speed;
        float inputy = Input.GetAxis("RightStickVertical") * Speed;
        float rotation = Input.GetAxis("Horizontal") * RotationSpeed;
        translationx *= Time.deltaTime;
        translationz *= Time.deltaTime;
        inputy *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(translationx, inputy, translationz);
        transform.Rotate(0, rotation, 0);
    }
}
