using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FAN_Tachometer : MonoBehaviour
{
    public Text startText;
    public int fan = 10000;

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        startText.text = "<b>" + fan.ToString() + "</b>";

    }
}
