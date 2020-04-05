using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeYouCanSpendInsideAHuman : MonoBehaviour
{
    public float timer = 30;
    public Text countDown;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        countDown.text = timer.ToString("0");
        
    }
}
