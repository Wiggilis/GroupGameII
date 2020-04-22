using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject CameraFollowObj;
    public Transform LookAtObject;

    public float CameraMoveSpeed = 120.0f;
    public float RotationSpeed = 60;


    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform targetPOS = CameraFollowObj.transform;

        // Determine which direction to rotate towards
        Vector3 targetDirection = targetPOS.position - transform.position;

        float tstep = CameraMoveSpeed * Time.deltaTime;

        // Moves toward the target position
        transform.position = Vector3.MoveTowards (transform.position, targetPOS.position, tstep);
        transform.LookAt(LookAtObject);

        //transform.Rotate(Vector3.right, targetDirection, Space.World);

    }
}
