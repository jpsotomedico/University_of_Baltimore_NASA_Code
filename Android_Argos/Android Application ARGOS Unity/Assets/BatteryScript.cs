using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryScript : MonoBehaviour
{

    public Text BatteryText;
    public float BatteryLossRate;
    public float BatteryAmount = 36000;


    public Text capacityText;
    public Text timeRemainingText;

    public string t_battery = "10:00:00";
    public float capacity = 30;
 
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
        

            capacityText.text = capacity.ToString("F2") + "amp-hr";
        
        timeRemainingText.text = t_battery;
    }
}
