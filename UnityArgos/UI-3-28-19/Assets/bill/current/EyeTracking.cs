using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI; 

public class EyeTracking : MonoBehaviour {

    public Button btn;
    public GameObject Camera;
    public GameObject canvas;
    public GameObject test;
    public int counter;
    public float zStuff;

    private Vector3 _heading;
    private Vector3 cursor_pos;
	// Use this for initialization
	void Start () {
        MLEyes.Start();
        zStuff = transform.position.z;
	}

    private void OnDisable()
    {
        MLEyes.Stop();
    }

    // Update is called once per frame
    void Update () {
	
	}

    private void LateUpdate()
    {
        if (counter == 120)
        {
            test.transform.position = new Vector3(canvas.transform.position.x, canvas.transform.position.y, canvas.transform.position.z);
            
            //MLEyes.Stop();
        }
        if (counter == 125)
        {
            //MLEyes.Start();
            counter = 0;
        }
        counter++;

        if (MLEyes.IsStarted)
        {
            RaycastHit rayHit;

            //_heading = MLEyes.FixationPoint - Camera.transform.position;
            _heading = MLEyes.FixationPoint ;
            cursor_pos = _heading - Camera.transform.position;
            _heading.z = 1;
            test.transform.position = _heading; // new Vector3(_heading.x, _heading.y, zStuff);

            if (Physics.Raycast(Camera.transform.position, _heading, out rayHit, 10.0f))
            {
                btn = GameObject.Find("ManualsMenuButton").GetComponent<Button>();
                if (rayHit.collider.gameObject.name == "ManualsMenuButton")
                    btn.onClick.Invoke();
            }
        }
    }
}
