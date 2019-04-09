using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterCapacityController : MonoBehaviour
{

    public Text h2oText;
    public Image h2oBar;
    public float h2oLossRate;
    public GameObject warning;
    public Transform spawnLocation;
    public Transform otherLocation;
    public Text warningText;

    public Text timeRemainingText;
    public Text gasPressureText;
    public Text liquidPressureText;

    private Color defaultColor = Color.green;
    private Color middleColor = Color.yellow;
    private Color criticalColor = Color.red;

    private string warningString = "H2O Levels Critical!";


    public float maxh2oAmount = 36000;
    public float h2oAmount = 36000;
    public string t_water = "10:00:00";
    public float gasPressure = 16;
    public float liquidPressure = 16;

    public float idealUsage = 0.75f;

    private bool warned = false;

    public bool direction = false;

    // Use this for initialization
    void Start()
    {
      //  InvokeRepeating("GenerateRandomData", 1.0f, 5.0f);
    }

   /* void GenerateRandomData()
    {
        if (direction)
        {
            gasPressure = gasPressure + 5;
            direction = false;
        }
        else
        {
            gasPressure = gasPressure - 5;
            direction = true;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        //if (gasPressure > 14)
        /*
        if (Random.value >= 0.5)
        {
            gasPressure = gasPressure + 5;
        }
        else
        {
            gasPressure = gasPressure - 5;
        }
        */

        //gasPressure -= ((h2oLossRate/*/idealUsage*/) / 60) * Time.deltaTime;

        // else
        //liquidPressure -= ((h2oLossRate/*/idealUsage*/) / 60) * Time.deltaTime;

        //     h2oAmount -= (h2oLossRate / idealUsage) * Time.deltaTime;
    }

    void LateUpdate()
    {
        h2oText.text = "<b>" + Mathf.RoundToInt((h2oAmount / maxh2oAmount) * 100).ToString() + "% </b>";
        h2oBar.fillAmount = h2oAmount / maxh2oAmount;
       // GameObject newWarning = null;

        if (gasPressure > 14 && gasPressure <= 16)
        {
          //  Destroy(newWarning);
            gasPressureText.color = Color.white;
            gasPressureText.text = gasPressure.ToString("F2") + " psia";
        }
        else
        {
           /* if (!warned)
            {
                warned = true;
                warningText.text = warningString;
                newWarning = Instantiate(warning, spawnLocation.position, Quaternion.identity, transform.parent);
                newWarning.GetComponent<WarningController>().StartMove(otherLocation, warningText, warningString);
            }*/
            gasPressureText.color = Color.red;
            gasPressureText.text = gasPressure.ToString("F2") + " psia";
        }

        if (liquidPressure > 14 && liquidPressure <= 16)
        {
           // Destroy(newWarning);
            liquidPressureText.color = Color.white;
            liquidPressureText.text = liquidPressure.ToString("F2") + " psia";
        }
       
        else
        {
           /* if (!warned)
            {
                warned = true;
                warningText.text = warningString;
                newWarning = Instantiate(warning, spawnLocation.position, Quaternion.identity, transform.parent);
                newWarning.GetComponent<WarningController>().StartMove(otherLocation, warningText, warningString);
            }*/
            liquidPressureText.color = Color.red;
            liquidPressureText.text = liquidPressure.ToString("F2") + " psia";
        }


        liquidPressureText.text = liquidPressure.ToString("F2") + "psia";

        /*string hours = Mathf.Floor(h2oAmount / 60 / 60).ToString("00");
        string minutes = Mathf.Floor((h2oAmount / 60) % 60).ToString("00");
        string seconds = (h2oAmount % 60).ToString("00");

        timeRemainingText.text = string.Format("{0}:{1}:{2}", hours, minutes, seconds);*/
        timeRemainingText.text = t_water;


        if (((h2oAmount / maxh2oAmount) * 100) < 30)
        {
            h2oBar.color = criticalColor;
            
            if (!warned)
            {
                warned = true;
                GameObject newWarning = Instantiate(warning, spawnLocation.position, Quaternion.identity, transform.parent);
                newWarning.GetComponent<WarningController>().StartMove(otherLocation, warningText, warningString);
            }
            
        }
        else if (((h2oAmount / maxh2oAmount) * 100) < 60)
        {
            h2oBar.color = middleColor;
        }

    }

}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class WaterCapacityController : MonoBehaviour
//{

//    public Text h2oText;
//    public Image h2oBar;
//    public float h2oLossRate;
//    public GameObject warning;
//    public Transform spawnLocation;
//    public Transform otherLocation;
//    public Text warningText;

//    public Text timeRemainingText;
//    public Text gasPressureText;
//    public Text liquidPressureText;

//    private Color defaultColor = Color.green;
//    private Color middleColor = Color.yellow;
//    private Color criticalColor = Color.red;

//    private string warningString = "H2O Levels Critical!";


//    public float maxh2oAmount = 36000;
//    public float h2oAmount = 36000;
//    public string t_water = "10:00:00";
//    public float gasPressure = 16;
//    public float liquidPressure = 16;

//    public float idealUsage = 0.75f;

//    // private bool warned = false;

//    //public bool direction = false;

//    // GameObject newWarning;


//    // Use this for initialization
//    void Start()
//    {
//        // newWarning = Instantiate(warning, spawnLocation.position, Quaternion.identity, transform.parent);
//        // InvokeRepeating("GenerateRandomData", 1.0f, 5.0f);
//    }

//    void GenerateRandomData()
//    {
//        if (direction)
//        {
//            gasPressure = gasPressure + 5;
//            direction = false;
//        }
//        else
//        {
//            gasPressure = gasPressure - 5;
//            direction = true;
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //if (gasPressure > 14)
//        /*
//        if (Random.value >= 0.5)
//        {
//            gasPressure = gasPressure + 5;
//        }
//        else
//        {
//            gasPressure = gasPressure - 5;
//        }
//        */

//        //gasPressure -= ((h2oLossRate/*/idealUsage*/) / 60) * Time.deltaTime;

//        // else
//        //liquidPressure -= ((h2oLossRate/*/idealUsage*/) / 60) * Time.deltaTime;

//        //     h2oAmount -= (h2oLossRate / idealUsage) * Time.deltaTime;
//    }

//    void LateUpdate()
//    {
//        h2oText.text = "<b>" + Mathf.RoundToInt((h2oAmount / maxh2oAmount) * 100).ToString() + "% </b>";
//        h2oBar.fillAmount = h2oAmount / maxh2oAmount;
//        //  newWarning.SetActiveRecursively(true);

//        if (gasPressure > 14 && gasPressure <= 16)
//        {
//            gasPressureText.color = Color.white;
//            gasPressureText.text = gasPressure.ToString("F2") + " psia";
//        }
//        else
//        {

//            //warned = true;

//            gasPressureText.color = Color.red;
//            gasPressureText.text = gasPressure.ToString("F2") + " psia";
//        }

//        if (liquidPressure > 14 && liquidPressure <= 16)
//        {
//            liquidPressureText.color = Color.white;
//            liquidPressureText.text = liquidPressure.ToString("F2") + " psia";
//        }
//        else
//        {
//            // warned = true;
//            liquidPressureText.color = Color.red;
//            liquidPressureText.text = liquidPressure.ToString("F2") + " psia";
//        }
//        /*
//        if (warned)
//        {
//            //newWarning = Instantiate(warning, spawnLocation.position, Quaternion.identity, transform.parent);
//           // newWarning.GetComponent<WarningController>().StartMove(otherLocation, warningText, warningString);
//        } else
//        {
//            // set transparency to 100% to hide warning symbol
//            Debug.Log("MADE IT!!");

//        }*/


//        //liquidPressureText.text = liquidPressure.ToString("F2") + "psia";

//        /*string hours = Mathf.Floor(h2oAmount / 60 / 60).ToString("00");
//        string minutes = Mathf.Floor((h2oAmount / 60) % 60).ToString("00");
//        string seconds = (h2oAmount % 60).ToString("00");

//        timeRemainingText.text = string.Format("{0}:{1}:{2}", hours, minutes, seconds);*/
//        timeRemainingText.text = t_water;


//        if (((h2oAmount / maxh2oAmount) * 100) < 30)
//        {
//            h2oBar.color = criticalColor;

//            if (!warned)
//            {
//                warned = true;
//                GameObject newWarning = Instantiate(warning, spawnLocation.position, Quaternion.identity, transform.parent);
//                newWarning.GetComponent<WarningController>().StartMove(otherLocation, warningText, warningString);
//            }

//        }
//        else if (((h2oAmount / maxh2oAmount) * 100) < 60)
//        {
//            h2oBar.color = middleColor;
//        }

//    }

//}