using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternalSuitPressureController : MonoBehaviour
{
    public float suitPressure = 2.0f;
    public Text myText;
    // Use this for initialization
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
      
      
            myText.text = "<b>" + suitPressure.ToString("F2") + " psid" + "%</b>";
            
      
   
        

    }
}
