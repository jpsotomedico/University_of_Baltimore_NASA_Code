using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class tableRaycast : MonoBehaviour {

    public Material FocusedMaterial, UnFocusedMaterial;
    private MeshRenderer _meshRenderer;
    public int raycastInstanceID;
	// Use this for initialization
	void Start () {
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        castMe();
	}

    public void castMe()
    {
      
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,out hit))
        {
            GameObject go = GameObject.Find("board(Clone)");
            // Debug.Log(hit.transform.tag);
           // if (hit.transform.tag == "table" )
           if (hit.Equals(go))
            {
                
                GameObject ret = GameObject.Find("reticle");
               // GameObject go = GameObject.Find("board(Clone)");
                Debug.Log(go.GetInstanceID());
                ret.transform.localScale = new Vector3(11.0f, 11.0f, 11.0f);
                _meshRenderer.material = FocusedMaterial;
               raycastInstanceID = hit.collider.gameObject.GetInstanceID();
                //Debug.Log("We a fn table");
            }
            else
            {
                GameObject ret = GameObject.Find("reticle");
                ret.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
                _meshRenderer.material = UnFocusedMaterial;
            }
        }
    }
}
