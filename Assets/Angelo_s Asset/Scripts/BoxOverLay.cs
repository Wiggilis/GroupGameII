using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOverLay : MonoBehaviour
{
    bool m_started;
    public LayerMask m_LayerMask;
    public Collider[] hitColliders;
    // Start is called before the first frame update

    void Start()
    {
        m_started = true;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MyCollision();
    }

    void MyCollision() {

        hitColliders = Physics.OverlapBox(gameObject.transform.position,transform.localScale, Quaternion.identity,m_LayerMask);
        int i = 0;

        while (i < hitColliders.Length) {

            print("Hit: " + hitColliders[i].name + 1);
            i++;
        
        }
 
    }

     void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (m_started)
        {
            Gizmos.DrawWireCube(transform.position, transform.localScale);

        }
    }
}
