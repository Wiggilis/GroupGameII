using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject CameraFollowObj;
    public GameObject PlayerObj;
    public GameObject CameraObj;

    Vector3 FollowPOS;

    public float CameraMoveSpeed = 120.0f;
    public float RotationSpeed = 100.0f;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //sets up rotation of sticks
        float rotationX = Input.GetAxis("Mouse X") * RotationSpeed;
        float rotationY = Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        rotationX *= Time.deltaTime;
        rotationY *= Time.deltaTime;
        transform.Rotate(0, rotationX, 0);



    }

    void LateUpdate ()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform targetPOS = CameraFollowObj.transform;

        // Determine which direction to rotate towards
        Vector3 targetDirection = targetPOS.position - transform.position;

        float step = CameraMoveSpeed * Time.deltaTime;
        
        // Moves toward the target position
        transform.position = Vector3.MoveTowards (transform.position, targetPOS.position, step);

        //transform.Rotate(Vector3.right, rotation * Time.deltaTime, Space.World);

    }
}
