using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRoomNum : MonoBehaviour
{
    public int humanRoomNumberRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        humanRoomNumberRef = other.gameObject.GetComponent<RoomNumber>().roomNumberRef;
    }
}
