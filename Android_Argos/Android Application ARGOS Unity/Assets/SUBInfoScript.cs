using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class SUBInfoScript : MonoBehaviour
{
    public Text startText;
    public int temp = 32;
    double pressure;

    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        startText.text = "<b>" + temp.ToString() + "</b>";
      
    }
}
