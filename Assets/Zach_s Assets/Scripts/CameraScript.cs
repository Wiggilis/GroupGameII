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
        float rotation = Input.GetAxis("RightStickHorizontal") * RotationSpeed;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);


    }

    void LateUpdate ()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform target = CameraFollowObj.transform;

        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards (transform.position, target.position, step);
    }
}
