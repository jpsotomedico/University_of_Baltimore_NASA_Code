using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour {
    public int instanceID;
    public int retID;
    // Use this for initialization
    public bool _active = false;
	void Awake () {
        instanceID = GetInstanceID();

	}
	
	// Update is called once per frame
	void Update () {
        retID = GameObject.Find("reticle").GetComponent<tableRaycast>().raycastInstanceID;
        if (instanceID == retID) 
        {
            transform.gameObject.SetActive(true);
        }
        else
        {
            transform.gameObject.SetActive(false);
        }
	}
}
