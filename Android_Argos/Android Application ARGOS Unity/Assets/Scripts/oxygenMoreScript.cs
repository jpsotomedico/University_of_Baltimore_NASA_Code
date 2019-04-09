using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oxygenMoreScript : MonoBehaviour
{
    public Text timeRemainingText;  //How long oxygen supply will last
    public Text primaryPressureText;       //Pressure remaining in tank
    public Text primaryUsageRateText;      //PSI usage per minute
    public Text secondaryPressureText;
    public Text secondaryUsageRateText;


    public float o2Amount = 36000;
    public string t_oxygen = "10:00:00";
    public float primaryPressure = 950;
    public float secondaryPressure = 950;
    public float primaryUsageRate = 1;
    public float secondaryUsageRate = 1;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   

    
}
