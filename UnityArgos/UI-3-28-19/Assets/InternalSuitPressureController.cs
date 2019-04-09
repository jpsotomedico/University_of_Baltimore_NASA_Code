using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternalSuitPressureController : MonoBehaviour {
    public float suitPressure = 2.0f;
    public Text myText;
    // Use this for initialization
    void Start () {

      //  myText = GetComponent<Text>();
      //  myText.text = suitPressure.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Q))
            suitPressure += 1f;
        if (Input.GetKeyDown(KeyCode.E))
            suitPressure -= 1f;*/

       // myText.text = suitPressure.ToString();
        if (suitPressure > 2 || suitPressure <= 4)
        {
            myText.color = Color.green;
            myText.text = "<b>" + suitPressure.ToString("F2") + " psid" + "%</b>";
            //GameObject newWarning = Instantiate(warning, spawnLocation.position, Quaternion.identity, transform.parent);
            //newWarning.GetComponent<WarningController>().StartMove(otherLocation.position, warningText, warningString);
        }
        else
        {
            myText.color = Color.red;
            myText.text = "<b>"+ suitPressure.ToString("F2") + " psid" + "%</b>";
        }

    }
}
