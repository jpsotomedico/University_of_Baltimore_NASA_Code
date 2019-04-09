using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenClear : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject SubPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickClear()
    {
        MainPanel.SetActive(false);
        SubPanel.SetActive(true);
    }

    public void OnClickReturn()
    {
        SubPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
}
