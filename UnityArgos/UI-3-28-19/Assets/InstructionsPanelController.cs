using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsPanelController : MonoBehaviour {

    public Text step;
    public int numSteps;
    public GameObject[] stepPanels;
    public GameObject[] animationPanels;
    public Transform stepSpawnPos;
    public Transform animationSpawnPos;
    public GameObject testAnimation;
    public Button previous;
    public Button next;
    public Button animButton;

    int stepNumber = 0;
    bool locked = true;
    GameObject unlockedCanvas;
    GameObject lockedCanvas;
    GameObject activeStep;
    GameObject activeAnimation;

	// Use this for initialization
	void Start () {
        step.text = "Included Parts";
        activeStep = Instantiate(stepPanels[stepNumber], stepSpawnPos.position, Quaternion.identity, transform);
        unlockedCanvas = GameObject.Find("UnlockedCanvas");
        lockedCanvas = GameObject.Find("LockedCanvas");
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void NextButton()
    {
        if(stepNumber < numSteps - 1)
        {

            if (activeStep != null)
                Destroy(activeStep);

            stepNumber++;
            activeStep = Instantiate(stepPanels[stepNumber], stepSpawnPos.position, Quaternion.identity, transform);

            if (stepNumber == 0)
                step.text = "Included Parts";
            else if (stepNumber == 1)
                step.text = "Required Tools";
            else
                step.text = "Step " + (stepNumber - 1).ToString();
        }
    }

    public void PreviousButton()
    {
        if(stepNumber > 0)
        {
            if (activeStep != null)
                Destroy(activeStep);

            stepNumber--;
            activeStep = Instantiate(stepPanels[stepNumber], stepSpawnPos.position, Quaternion.identity, transform);

            if (stepNumber == 0)
                step.text = "Included Parts";
            else if (stepNumber == 1)
                step.text = "Required Tools";
            else
                step.text = "Step " + (stepNumber + 1).ToString();
        }
    }

    public void AnimationButton()
    {
        if(activeAnimation != null)
            Destroy(activeAnimation);

        if(stepNumber > 1)
            activeAnimation = Instantiate(animationPanels[stepNumber - 2], animationSpawnPos.position, Quaternion.identity, transform);
    }

    public void DeleteButton()
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
