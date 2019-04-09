using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning02 : MonoBehaviour {
    private float oxygenCheck = 0.0f;
    public Text warning;
    private string warn = "";
    



    // Update is called once per frame
    void Update()
    {
        oxygenCheck = GameObject.Find("Oxygen").GetComponent<LevelO2>().oxygenLevel;
        if (oxygenCheck < 30)
        {
            warn = "Danger";
        }
        else if (oxygenCheck >= 30)
        {
            warn = "";
        }
        warning.text = warn;
    }
}