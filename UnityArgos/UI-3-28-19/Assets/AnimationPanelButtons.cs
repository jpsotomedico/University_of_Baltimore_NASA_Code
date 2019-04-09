using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPanelButtons : MonoBehaviour {

    bool locked = true;
    GameObject unlockedCanvas;
    GameObject lockedCanvas;

    // Use this for initialization
    void Start () {
        unlockedCanvas = GameObject.Find("UnlockedCanvas");
        lockedCanvas = GameObject.Find("LockedCanvas");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CloseButton()
    {
        Destroy(gameObject);
    }

    public void LockButton()
    {
        if (locked)
        {
            locked = false;
            transform.parent = unlockedCanvas.transform;
        }
        else
        {
            locked = true;
            transform.parent = lockedCanvas.transform;
        }
    }
}
