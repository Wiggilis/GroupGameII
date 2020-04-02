using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float movementSpeed = 10;
    public float turningSpeed = 60;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float rotHorizontal = Input.GetAxis("Mouse X") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, rotHorizontal, 0);

        float moveVertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, moveVertical);

        float moveHorizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(moveHorizontal, 0, 0);

        float mouseY = Input.GetAxis("RightStickVertical")* movementSpeed * Time.deltaTime;
        transform.Translate(0, -mouseY, 0);
    }

    void OnCollisionEnter(Collision Collision)
    {
        //print(Collision.collider.name);
        if (Collision.gameObject.tag == "Wall")
        {
            Collision.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (Collision.gameObject.tag == "GameObject")
        {
            Collision.gameObject.GetComponent<Collider>().enabled = false;
        }
        if (Collision.gameObject.tag == "Human")
        {
            Collision.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
