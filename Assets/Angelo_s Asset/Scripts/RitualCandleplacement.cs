using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualCandleplacement : MonoBehaviour
{
    int candlenum;
    public GameObject RCandle;
    public GameObject RCandle1;
    public GameObject RCandle2;
    public GameObject RCandle3;
    public GameObject RCandle4;
    public GameObject RCandle5;
    public GameObject RCandle6;
    public GameObject RCandle7;
    public GameObject RCandle8;
    public GameObject RCandle9;
    private GameObject player;
    public GameObject cursor;

    RaycastHit rhinfo;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        RCandle.SetActive(false);
        RCandle1.SetActive(false);
        RCandle2.SetActive(false);
        RCandle3.SetActive(false);
        RCandle4.SetActive(false);
        RCandle5.SetActive(false);
        RCandle6.SetActive(false);
        RCandle7.SetActive(false);
        RCandle8.SetActive(false);
        RCandle9.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerPossesiom>().isClick == true) {

            cursor.SetActive(true);
            GetRayInfo();

            if (Input.GetKeyDown(KeyCode.Mouse0)) {

                
                if (rhinfo.collider.tag == "Angelo")
                {
                   

                    if (GetComponent<Candlecounters>().candle > 0) {

                        candlenum += GetComponent<Candlecounters>().candle;
                        GetComponent<Candlecounters>().candle = 0;
                        if (candlenum >= 1) {

                            RCandle.SetActive(true);

                        }

                        if (candlenum >= 2)
                        {

                            RCandle1.SetActive(true);

                        }

                        if (candlenum >= 3)
                        {

                            RCandle2.SetActive(true);

                        }

                        if (candlenum >= 4)
                        {

                            RCandle3.SetActive(true);

                        }

                        if (candlenum >= 5)
                        {

                            RCandle4.SetActive(true);

                        }

                        if (candlenum >= 6)
                        {

                            RCandle5.SetActive(true);

                        }

                        if (candlenum >= 7)
                        {

                            RCandle6.SetActive(true);

                        }

                        if (candlenum >= 8)
                        {

                            RCandle7.SetActive(true);

                        }

                        if (candlenum >= 9)
                        {

                            RCandle8.SetActive(true);

                        }

                        if (candlenum >= 10)
                        {

                            RCandle9.SetActive(true);

                        }
                    }

                }
            }
            
        }//cursor.SetActive(false);
    }
    public void GetRayInfo()
    {
        Ray toCursor = Camera.main.ScreenPointToRay(cursor.transform.position);
        bool didgit = Physics.Raycast(toCursor, out rhinfo, 500.0f);

    }
}
