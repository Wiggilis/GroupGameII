using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingToScript : MonoBehaviour
{
    private Vector2 mousePosition;
    [SerializeField] private Material highlightMaterial;
    public GameObject[] interactables;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        interactables = GameObject.FindGameObjectsWithTag("GameObject");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "GameObject")
                {
                    //Debug.Log("It's working!");
                    var selection = hitInfo.transform;
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial;
                    }
                }
                else
                {
                    //Debug.Log("nopz");
                }
            }
            else
            {
                //Debug.Log("No hit");
            }
           // Debug.Log("Mouse is down");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactables.Length > 0)
            {
                Invoke("changeMaterial", 1.0f);
            }
        }


    }

    void changeMaterial()
    {

    }
}
