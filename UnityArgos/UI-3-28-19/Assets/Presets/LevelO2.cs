using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelO2 : MonoBehaviour {
    public float oxygenLevel = 100.0f;
    private int counter = 0;
    public Text display;



    // Update is called once per frame
    void Update()
    {
        if (counter == 60)
        {
            oxygenLevel--;
            counter = 0;
        }
        display.text = "oxygenLevel" + oxygenLevel;
        counter++;
    }
}
