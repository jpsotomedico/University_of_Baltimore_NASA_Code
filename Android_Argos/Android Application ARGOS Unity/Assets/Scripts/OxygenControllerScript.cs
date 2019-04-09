using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenControllerScript : MonoBehaviour
{


    public Text timeRemainingText;  //How long oxygen supply will last
    public Text primaryPressureText;       //Pressure remaining in tank
    public Text primaryUsageRateText;      //PSI usage per minute
    public Text secondaryPressureText;
    public Text secondaryUsageRateText;

    public float maxO2Amount = 36000;
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

    void LateUpdate()
    {

        //primary usage rate

        primaryUsageRateText.text = primaryUsageRate.ToString("F2") + " psi/min";
        //secondary usage rate
        secondaryUsageRateText.text = secondaryUsageRate.ToString("F2") + " psi/min";
        

        //primary pressure

        primaryPressureText.text = primaryPressure.ToString("F2") + "psia";


        //secondary pressure
        secondaryPressureText.text = secondaryPressure.ToString("F2") + "psia";
       

        timeRemainingText.text = t_oxygen;

    }
}
