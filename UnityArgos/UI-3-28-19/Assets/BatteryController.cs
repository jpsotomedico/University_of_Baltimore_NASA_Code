using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryController : MonoBehaviour
{

    public Text BatteryText;
    public Image BatteryBar;
    public float BatteryLossRate;
    public GameObject warning;
    public Transform spawnLocation;
    public Transform otherLocation;
    public Text warningText;

    private Color defaultColor = Color.green;
    private Color middleColor = Color.yellow;
    private Color criticalColor = Color.red;

    private string warningString = "Battery Levels Critical!";

    public Text capacityText;
    public Text timeRemainingText;

    public float maxBattery = 36000;
    public float BatteryAmount = 36000;
    public string t_battery = "10:00:00";
    public float capacity = 30;
    public float idealUsage = 0.05f;

    private bool warned = false;

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
        BatteryText.text = "<b>" + Mathf.RoundToInt((BatteryAmount / maxBattery) * 100).ToString() + "% </b>";
        BatteryBar.fillAmount = BatteryAmount / maxBattery;
        

        if (capacity > 0 && capacity <= 30)
        {
            capacityText.color = Color.white;
            capacityText.text = capacity.ToString("F2") + "amp-hr";
        }
        else
        {
            capacityText.color = Color.red;
            capacityText.text = capacity.ToString("F2") + "amp-hr";
        }
        

        timeRemainingText.text = t_battery;

        if (((BatteryAmount / maxBattery) * 100) < 40)
        {
            BatteryBar.color = criticalColor;
            if (!warned)
            {
                warned = true;
                GameObject newWarning = Instantiate(warning, spawnLocation.position, Quaternion.identity, transform.parent);
                newWarning.GetComponent<WarningController>().StartMove(otherLocation, warningText, warningString);
            }
        }
        else if (((BatteryAmount / maxBattery) * 100) < 70)
            BatteryBar.color = middleColor;
    }
}
