using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class evaTime1 : MonoBehaviour {
    public float timeRemaining = 0f;
    public Text startText;


    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        timeRemaining += Time.deltaTime;

        string hours = Mathf.Floor(timeRemaining / 60 / 60).ToString("00");
        string minutes = Mathf.Floor((timeRemaining / 60)% 60).ToString("00");
        string seconds = (timeRemaining % 60).ToString("00");

        startText.text = (string.Format("<b>{0}:{1}:{2}</b>", hours, minutes, seconds));

    }
}

