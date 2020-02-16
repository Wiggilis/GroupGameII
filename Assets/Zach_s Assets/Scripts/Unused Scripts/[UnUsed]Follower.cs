using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private Vector3 _cameraOffset;
    public Transform PlayerTransform;
    public bool LookAtPlayer = false;
  
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = PlayerTransform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position +_cameraOffset;

        transform.position = Vector3.Slerp(PlayerTransform.position, newPos, SmoothFactor);

        if (LookAtPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}