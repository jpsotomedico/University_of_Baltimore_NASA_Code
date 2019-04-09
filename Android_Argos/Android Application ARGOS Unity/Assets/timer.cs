using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    Text text;
    float theTime;
    public float speed = 1;
    bool playing;
    int count;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playing == true)
        {
            theTime += Time.deltaTime * speed;
            string hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00");
            string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            string seconds = (theTime % 60).ToString("00");
            text.text = hours + ":" + minutes + ":" + seconds;
            
        }
    }

    public void ClickBegin()
    {
        playing = true;

    }

    public void ClickStop()
    {
        playing = false;

        count++;
        if(count == 2)
        {
            Reset();
        }
    }
    public void Reset()
    {
        Debug.Log("called reset");
        text.text="00:00:00";
        theTime = 0;
        count = 0;
    }
}