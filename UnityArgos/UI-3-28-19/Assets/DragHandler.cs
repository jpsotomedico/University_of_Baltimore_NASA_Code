using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour {

    bool dragging = false;
    Transform objectToDrag;
    List<RaycastResult> hitObjects = new List<RaycastResult>();
    public float offsetX;
    public float offsetY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if(objectToDrag != null)
            {
                Debug.Log("Drag");
                dragging = true;
            }

            Debug.Log("Click");
        }

        if (dragging)
        {
            var pointer = new PointerEventData(EventSystem.current);
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");
            pointer.position = Input.mousePosition;

            Vector3 offset = new Vector3(195, -153.9135f, 0);
            //objectToDrag.parent.localPosition = new Vector3(Input.mousePosition.x , Input.mousePosition.y, 0);
            objectToDrag.parent.localPosition += new Vector3(h, v, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(objectToDrag != null)
            {
                dragging = false;
                objectToDrag = null;
            }
        }

    }

    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;

        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0)
            return null;

        return hitObjects[0].gameObject;
    }

    private Transform GetDraggableTransformUnderMouse()
    {
        GameObject clickedObject = GetObjectUnderMouse();

        if (clickedObject != null && clickedObject.tag == "UIDraggable")
            return clickedObject.transform;
        

        return null;
    }
}
