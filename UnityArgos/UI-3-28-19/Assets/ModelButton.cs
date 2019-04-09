using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelButton : MonoBehaviour {

    public GameObject modelPrefab;
    Vector3 pos = new Vector3(0, -0.15f, 0f);
    GameObject myModel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (myModel!= null)
        {
            Destroy(myModel);
            myModel = Instantiate(modelPrefab, Camera.main.transform.forward + pos, Quaternion.identity);
        }
        else
            myModel = Instantiate(modelPrefab, Camera.main.transform.forward + pos, Quaternion.identity);
    }
}
