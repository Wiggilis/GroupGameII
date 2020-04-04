using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    float rotationX;
    float rotationY;
    float distanceZ;
    public float turnSpeed = 4.0f;
    public Transform player;

    void Start()
    {
        
    }

    private void Update()
    {
        rotationX = Input.GetAxis("Horizontal");
        rotationY = Input.GetAxis("Vertical");
        distanceZ = Input.GetAxis("Mouse ScrollWheel");
    }
    void LateUpdate()
    {
        transform.Translate(rotationX * turnSpeed * Time.deltaTime, 0, 0);
        transform.Translate(0, rotationY * turnSpeed * Time.deltaTime, 0);
        //distanceZ = Mathf.Clamp(distanceZ, -10f, -3f);
        transform.Translate(0, 0, distanceZ * turnSpeed);
        transform.LookAt(player.position);
    }
}
