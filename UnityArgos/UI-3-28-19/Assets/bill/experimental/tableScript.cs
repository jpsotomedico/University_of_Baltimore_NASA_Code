using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class tableScript : MonoBehaviour
{
    

    public Transform ctransform; // camera's transform
    public GameObject prefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame


    public void createPrefab(Vector3 point, Vector3 normal)
    {
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
        GameObject go = Instantiate(prefab, point, rotation);

    }
}
