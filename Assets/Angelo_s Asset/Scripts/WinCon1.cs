using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinCon1 : MonoBehaviour
{
    public GameObject cursor;
    private GameObject gameController;
    private GameObject player;
    public int num;
    RaycastHit rhinfo;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        raytocast();

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            callthistoadd();
        }
    }

    void raytocast() {

        Ray toCursor = Camera.main.ScreenPointToRay(cursor.transform.position);
        bool didgit = Physics.Raycast(toCursor, out rhinfo, 500.0f);

    }

    void callthistoadd() {

        if (rhinfo.collider.tag == "GameObject")
        {
            Destroy(rhinfo.collider.gameObject);
            gameController.GetComponent<GameController>().IncreaseCounter();
            player.GetComponent<PlayerPossesiom>().HumanRef.GetComponent<Candlecounters>().candle++;
            
        }
    }
}
