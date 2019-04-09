using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsButton : MonoBehaviour {

    public GameObject instructionShell;

    GameObject myShell;
    Vector3 pos = new Vector3(0, -0.15f, 0f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (myShell != null)
            Destroy(myShell);

        myShell = Instantiate(instructionShell, Camera.main.transform.forward, Quaternion.identity, transform.parent.parent.parent);
    }
}
