using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class pointsOnCircle : MonoBehaviour {
   
    private bool inc = false;
    public float _x;
    public float _z;
    public Vector3 pos;
    public float radius = 1.0f;
    public float theta = 90.0f;
    public GameObject prefab;


	// Use this for initialization
	void Start () {
       
        Vector3 pos = new Vector3(0, 0, radius);

        Instantiate(prefab, pos, Quaternion.identity);
	}

    // Update is called once per frame
    void Update()
    {
        revolution();          
    }//end update




    public void revolution()
    {
        if (theta == 90)
        {
            inc = false;

        }
        else if (theta == 0)
        {
            inc = true;
        }
        if (inc)
        {
            theta += 0.0125f;
        }
        else
        {
            theta -= 0.0125f;
        }
        GameObject go = GameObject.Find("board(Clone)");
        Vector3 pos = go.transform.position;
        //pos.x -= 0.005f;
        //go.transform.position = pos;



        _x = radius * Mathf.Sin(theta);
        _z = radius * Mathf.Cos(theta);

        pos.x = _x;
        pos.z = _z;
        go.transform.position = pos;
    }

       
    
    
}
