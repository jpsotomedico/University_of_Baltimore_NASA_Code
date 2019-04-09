using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningController : MonoBehaviour {

    public float moveSpeed;
    public float scaleSpeed;

    bool moving = false;
    Transform targetPos;

    bool scaling = false;
    Vector3 targetScale = new Vector3(0.38f, 0.38f, 0.38f);

    bool flash = true;
    public float flashSpeed;
    int flashCount;
    public int maxFlashes;

    private Text warningText;

    Image myImage;

    // Use this for initialization
    void Start () {
        myImage = gameObject.GetComponent<Image>();
        warningText.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, transform.rotation.w);

        if (flashCount <= maxFlashes)
        {
            if (flash)
            {
                Color temp = myImage.color;
                float myAlpha = myImage.color.a;
                myAlpha = Mathf.Lerp(myAlpha, 0, flashSpeed * Time.deltaTime);

                if (myAlpha < 0.1)
                    myAlpha = 0;

                temp.a = myAlpha;
                myImage.color = temp;

                if(myAlpha <= 0.1)
                {
                    flash = false;
                    flashCount++;
                }
            }
            else
            {
                Color temp = myImage.color;
                float myAlpha = myImage.color.a;
                myAlpha = Mathf.Lerp(myAlpha, 1, flashSpeed * Time.deltaTime);

                temp.a = myAlpha;
                myImage.color = temp;

                if (myAlpha >= 0.9)
                {
                    flash = true;
                    flashCount++;
                }
            }
        }

        else
        {
            if (warningText.gameObject.active)
                warningText.gameObject.SetActive(false);
            if (moving)
            {
                transform.position = Vector3.Slerp(transform.position, targetPos.position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, targetPos.transform.position) < 0.01f)
                {
                    moving = false;
                    transform.parent = targetPos;
                }
            }

            if (scaling)
            {
                transform.localScale = Vector3.Slerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);

                if (transform.localScale == targetScale)
                    scaling = false;
            }
        }
	}

    public void StartMove(Transform target, Text targetText, string warningString)
    {
        targetPos = target;
        warningText = targetText;
        warningText.text = warningString;
        moving = true;
        scaling = true;
    }
}
