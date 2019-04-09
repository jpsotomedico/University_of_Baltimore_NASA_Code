﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    float rbgValue = 0.5f;
    void onGUI()
    {
        rbgValue = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 50, 90, 100, 30), rbgValue, 0f, 1.0f);

    }
    // Update is called once per frame
    void Update()
    {
        RenderSettings.ambientLight = new Color(rbgValue, rbgValue, rbgValue, 1);
    }
}
    
