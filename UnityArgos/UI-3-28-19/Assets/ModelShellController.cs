using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelShellController : MonoBehaviour {

    bool locked = false;
    public ModelButton myButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeleteButton()
    {
        Destroy(gameObject);
    }

    public void LockButton()
    {
        if (locked)
        {
            transform.parent = null;
            locked = false;
        }
        else
        {
            locked = true;
            transform.parent = Camera.main.transform;
        }
    }
}
