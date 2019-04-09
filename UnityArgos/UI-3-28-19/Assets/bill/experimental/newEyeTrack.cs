using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;

public class newEyeTrack : MonoBehaviour {
    public Button btn;
    public GameObject Camera;
    private Vector3 _heading;


    public GameObject test;
    public float zStuff;
    // Use this for initialization
    void Start () {
        MLEyes.Start();
        transform.position = Camera.transform.position + Camera.transform.forward * 1.0f; // this moves the position of object holding script
	}

    private void OnDisable()
    {
        MLEyes.Stop();
    }

    // Update is called once per frame
    void Update () {
		if (MLEyes.IsStarted)
        {
            RaycastHit rayhit;
            _heading = MLEyes.FixationPoint - Camera.transform.position;
            test.transform.position = new Vector3(_heading.x, _heading.y, zStuff);
            if (Physics.Raycast(Camera.transform.position, _heading, out rayhit, 10.0f)) ;
            {

                btn = GameObject.Find("ManualsMenuButton").GetComponent <Button>();
                if (rayhit.collider.gameObject.tag == "ManualsMenuButton")
                {
                    btn.onClick.Invoke();
                    Debug.Log("We hit bih");
                }
            }
        }
	}
}
