using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //Player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        var mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDirection = Vector2.Scale(mouseDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDirection.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDirection.y, 1f / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -45f, 45f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        //Player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Player.transform.up);
        //transform.LookAt(Player.transform.position);
    }
}
