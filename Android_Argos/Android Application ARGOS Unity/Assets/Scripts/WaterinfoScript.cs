using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterinfoScript : MonoBehaviour
{

    public Text timeRemainingText;
    public Text gasPressureText;
    public Text liquidPressureText;

    public string t_water = "10:00:00";
    public float gasPressure = 16;
    public float liquidPressure = 16;



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


        gasPressureText.text = gasPressure.ToString("F2") + " psia";


        liquidPressureText.text = liquidPressure.ToString("F2") + "psia";

        timeRemainingText.text = t_water;

    }

}