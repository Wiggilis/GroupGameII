using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public Rigidbody playerRb;
    public GameObject player;

    public float Speed = 10.0f;
    public float RotationSpeed = 100.0f;

	void Update ()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float translationx = Input.GetAxis("Horizontal") * Speed;
        float translationz = Input.GetAxis("Vertical") * Speed;
        float inputy = Input.GetAxis("RightStickVertical") * Speed;
        float rotation = Input.GetAxis("RightStickHorizontal") * RotationSpeed;
        translationx *= Time.deltaTime;
        translationz *= Time.deltaTime;
        inputy *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(translationx, inputy, translationz);
        transform.Rotate(0, rotation, 0);
    }

    void OnCollisionEnter(Collision Collision)
    {
        print(Collision.collider.name);
        if (Collision.gameObject.tag == "Wall")
        {
            Collision.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}