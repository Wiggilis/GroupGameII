using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  
    public GameObject humanCandleRef;
    public bool fuctionwascalled = false;
    int counter;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fuctionwascalled == true) {
            Addcounter();
        }
        
    }

    void Addcounter() {

        counter++;
        print(counter);
        fuctionwascalled = false;
    
    }
}
