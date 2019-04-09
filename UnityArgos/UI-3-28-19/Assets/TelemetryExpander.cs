using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelemetryExpander : MonoBehaviour {

    public TelemetryExpander[] otherTelemetries;
    public TelemetryExpander[] lowerTelemetries;
    public RectTransform myPanel;
    public bool expanded = false;
    public Vector3 originalPos;

    // Use this for initialization
    void Start() {
        originalPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void OnCLick()
    {
        if (expanded)
            Contract();
        else
            Expand();
            
    }

    public void Expand()
    {
        myPanel.gameObject.SetActive(true);
        expanded = true;

        foreach (TelemetryExpander other in otherTelemetries)
        {
            if (other.expanded)
                other.Contract();
        }

        foreach (TelemetryExpander other in lowerTelemetries)
        {
            float shiftY = other.transform.localPosition.y - (myPanel.sizeDelta.y /*+ (GetComponent<RectTransform>().sizeDelta.y)*/);
            other.transform.localPosition = new Vector3(other.transform.localPosition.x, shiftY, other.transform.localPosition.z);
        }
        //foreach (TelemetryExpander other in otherTelemetries)
        //{
        //    other.transform.position = other.originalPos;
        //    if (other.expanded)
        //        other.Contract();
        //    if (other.GetComponent<RectTransform>().anchoredPosition.y < GetComponent<RectTransform>().anchoredPosition.y)
        //    {
        //        float shiftY = other.transform.localPosition.y - (myPanel.sizeDelta.y + (GetComponent<RectTransform>().sizeDelta.y));
        //        other.transform.localPosition = new Vector3(other.transform.localPosition.x, shiftY, other.transform.localPosition.z);
        //    }
        //}
    }

    public void Contract()
    {
        if (expanded)
        {
            myPanel.gameObject.SetActive(false);
            expanded = false;

            foreach (TelemetryExpander other in lowerTelemetries)
            {
                other.transform.position = other.originalPos;
            }

            //foreach (TelemetryExpander other in otherTelemetries)
            //{
            //    if (other.GetComponent<RectTransform>().anchoredPosition.y < GetComponent<RectTransform>().anchoredPosition.y)
            //    {
            //        float shiftY = other.transform.localPosition.y + (myPanel.sizeDelta.y + (GetComponent<RectTransform>().sizeDelta.y));
            //        other.transform.localPosition = new Vector3(other.transform.localPosition.x, shiftY, other.transform.localPosition.z);
            //    }
            //}
        }
    }
}
