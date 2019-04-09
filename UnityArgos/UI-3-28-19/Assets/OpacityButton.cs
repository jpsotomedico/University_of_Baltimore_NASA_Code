using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityButton : MonoBehaviour {

    public GameObject OpacitySlider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (!OpacitySlider.activeInHierarchy)
            OpacitySlider.SetActive(true);
        else
            OpacitySlider.SetActive(false);
    }
}
