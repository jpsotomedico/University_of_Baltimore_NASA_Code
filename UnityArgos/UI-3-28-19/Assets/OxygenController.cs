using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenController : MonoBehaviour
{

    public Text o2Text;
    public Image o2Bar;             //O2 tank meter
    public float o2LossRate;        //PSI usage per minute
    public GameObject warning;      //Reference to warning prefab
    public Transform spawnLocation; //Spawn location of warning
    public Transform otherLocation; //Location for warning to move to
    public Text warningText;        //Text to display for warning

    public Text timeRemainingText;  //How long oxygen supply will last
    public Text primaryPressureText;       //Pressure remaining in tank
    public Text primaryUsageRateText;      //PSI usage per minute
    public Text secondaryPressureText;
    public Text secondaryUsageRateText;

    private Color defaultColor = Color.green;
    private Color middleColor = Color.yellow;
    private Color criticalColor = Color.red;

    private string warningString = "02 Levels Critical!";

    public float maxO2Amount = 36000;
    public float o2Amount = 36000;
    public string t_oxygen = "10:00:00";
    public float primaryPressure = 950;
    public float secondaryPressure = 950;
    public float primaryUsageRate = 1;
    public float secondaryUsageRate = 1;

    public float idealUsage = 0.75f;

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
        o2Text.text = "<b>" + Mathf.RoundToInt((o2Amount / maxO2Amount) * 100).ToString() + "% </b>";
        o2Bar.fillAmount = o2Amount / maxO2Amount;
        //primary usage rate
        if (primaryUsageRate>0.5 && primaryUsageRate <= 1)
        {
            primaryUsageRateText.color = Color.white;
            primaryUsageRateText.text = primaryUsageRate.ToString("F2") + " psi/min";
        }
        else
        {
            primaryUsageRateText.color = Color.red;
            primaryUsageRateText.text = primaryUsageRate.ToString("F2") + " psi/min";
        }

        //secondary usage rate
        if (secondaryUsageRate > 0.5 && secondaryUsageRate <= 1)
        {
            secondaryUsageRateText.color = Color.white;
            secondaryUsageRateText.text = secondaryUsageRate.ToString("F2") + " psi/min";
        }
        else
        {
            secondaryUsageRateText.color = Color.red;
            secondaryUsageRateText.text = secondaryUsageRate.ToString("F2") + " psi/min";
        }

        //primary pressure
        if (primaryPressure > 750 && primaryPressure <= 950)
        {
            primaryPressureText.color = Color.white;
            primaryPressureText.text = primaryPressure.ToString("F2") + "psia";
        }
        else
        {
            primaryPressureText.color = Color.red;
            primaryPressureText.text = primaryPressure.ToString("F2") + "psia";
        }

        //secondary pressure
        if (secondaryPressure > 750 && secondaryPressure <= 950)
        {
            secondaryPressureText.color = Color.white;
            secondaryPressureText.text = secondaryPressure.ToString("F2") + "psia";
        }
        else
        {
            secondaryPressureText.color = Color.red;
            secondaryPressureText.text = secondaryPressure.ToString("F2") + "psia";
        }

            
            timeRemainingText.text = t_oxygen;

        if (((o2Amount / maxO2Amount) * 100) < 30)
        {
            o2Bar.color = criticalColor;
            if (!warned)
            {
                warned = true;
                GameObject newWarning = Instantiate(warning, spawnLocation.position, Quaternion.identity, transform.parent);
                newWarning.GetComponent<WarningController>().StartMove(otherLocation, warningText, warningString);
            }
        }
        else if (((o2Amount / maxO2Amount) * 100) < 60)
            o2Bar.color = middleColor;
    }
}
