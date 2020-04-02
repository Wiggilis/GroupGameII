using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleText : MonoBehaviour
{
    public Text candlesFound;
    public GameObject ControllerRef;
    
 
    // Update is called once per frame
    void Update()
    {
        
        candlesFound.text = "Candles Found: " + ControllerRef.GetComponent<GameController>().counter + "/3";
 
    }

   
      
}
