using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUB_Pressure : MonoBehaviour {
    public Sprite pressure_red;
    public Text startText;
    public double pressure = 2;
    // Use this for initialization
    void Start()
    {
      //  InvokeRepeating("GenerateRandomData", 1.0f, 5.0f);
    }
    /*
    void GenerateRandomData()
    {
        if (Random.value >= 0.5)
        {
            pressure = pressure + 2;
        }
        else
        {
            pressure = pressure - 3;
        }

    }
    */

    // Update is called once per frame
    void Update()
    {
        startText.text = "<b>" + pressure.ToString() + "</b>";
        if (pressure < 2 || pressure >= 4)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = pressure_red;
        }
    }
}
