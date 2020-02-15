using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleText : MonoBehaviour
{
    private int candles = 0;
    public Text candlesFound;
 
    // Update is called once per frame
    void Update()
    {
        candlesFound.text = "Candles Found: " + candles;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            candles++;
        }
    }
}
